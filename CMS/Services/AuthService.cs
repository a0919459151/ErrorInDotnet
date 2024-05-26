using CMS.Contracts.Auth;
using CMS.Services.Interfaces;
using Hangfire;

namespace CMS.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly MailSender _mailSender;
    private readonly HttpContextService _httpContextService;
    private readonly RandomService _randomService;
    private readonly IBackgroundJobClient _backgroundJobClient;

    public AuthService(
        AppDbContext context,
        MailSender mailSender,
        HttpContextService httpContextService,
        RandomService randomService,
        IBackgroundJobClient backgroundJobClient)
    {
        _context = context;
        _mailSender = mailSender;
        _httpContextService = httpContextService;
        _randomService = randomService;
        _backgroundJobClient = backgroundJobClient;
    }

    public async Task<Result> Login(LoginViewModel model)
    {
        // Query
        var admin = await _context.Admins
            .AsNoTracking()
            .Where(a => a.Account == model.Account)
            .FirstOrDefaultAsync();

        // Not found
        if (admin is null)
        {
            return Result.NotFound("Account not found");
        }

        // Verify password
        if (model.Password != admin.Password)
        {
            return Result.Unauthorized("Password is incorrect");
        }

        // CookieLogin
        await _httpContextService.CookieLogin(admin, model.IsRememberMe);

        return Result.Success();
    }

    public async Task<Result> ForgetPassword(ForgetPasswordViewModel model)
    {
        // Query
        var admin = await _context.Admins
            .Where(a => a.Account == model.Account)
            .FirstOrDefaultAsync();

        // Not found
        if (admin is null)
        {
            return Result.NotFound("Account not found");
        }

        // Generate token
        string resetToken = _randomService.GenerateToken(32);

        // Update
        admin.ResetPasswordToken = resetToken;
        admin.ResetPasswordExpireTime = DateTime.Now.AddHours(1);

        // Save
        await _context.SaveChangesAsync();

        var resetPasswordUrl = $"https://localhost:7100/Auth/ResetPassword?resetToken={resetToken}";
        
        // Enqueue email sending job
        _backgroundJobClient.Enqueue(() => _mailSender.SendResetPasswordMail(admin.Account, resetPasswordUrl));

        return Result.Success();
    }

    public async Task<Result> GetAccountByResetToken(string resetToken)
    {
        var admin = await _context.Admins
            .Where(a => a.ResetPasswordToken == resetToken)
            .FirstOrDefaultAsync();

        if (admin is null)
        {
            return Result.NotFound("Token not found");
        }

        return Result.Success(admin.Account);
    }

    public async Task<Result> ResetPassword(ResetPasswordViewModel model)
    {
        // Query
        var admin = await _context.Admins
            .Where(a => a.ResetPasswordToken == model.ResetPasswordToken)
            .FirstOrDefaultAsync();

        // Not found
        if (admin is null)
        {
            return Result.NotFound("Token not found");
        }

        // Check if expired
        if (admin.ResetPasswordExpireTime.IsBefore(DateTime.Now))
        {
            return Result.BadRequest("Token expired");
        }

        // Reset password
        admin.Password = model.NewPassword;
        admin.ResetPasswordToken = null;
        admin.ResetPasswordExpireTime = null;
        admin.UpdateAt = DateTime.Now;

        // Save
        await _context.SaveChangesAsync();

        return Result.Success();
    }
}
