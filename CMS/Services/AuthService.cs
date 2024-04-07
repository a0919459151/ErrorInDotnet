using CMS.Contracts.Auth;
using CMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CMS.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly MailSender _mailSender;
    private readonly HttpContextService _httpContextService;

    public AuthService(
        AppDbContext context,
        MailSender mailSender,
        HttpContextService httpContextService)
    {
        _context = context;
        _mailSender = mailSender;
        _httpContextService = httpContextService;
    }

    public async Task<Result> Login(LoginViewModel model)
    {
        Result result = new();

        // Query
        var admin = await _context.Admins
            .AsNoTracking()
            .Where(a => a.Account == model.Account)
            .FirstOrDefaultAsync();

        // Not found
        if (admin is null)
        {
            return result.NotFound("Account not found");
        }

        // Verify password
        if (model.Password != admin.Password)
        {
            return result.Unauthorized("Password is incorrect");
        }

        // Login
        await _httpContextService.Login(admin, model.IsRememberMe);

        return result.Success();
    }

    public async Task<Result> ForgetPassword(ForgetPasswordViewModel model)
    {
        Result result = new();

        // Query
        var admin = await _context.Admins
            .Where(a => a.Account == model.Account)
            .FirstOrDefaultAsync();

        // Not found
        if (admin is null)
        {
            return result.NotFound("Account not found");
        }

        // Generate token
        string resetToken = GenerateToken();

        // Update
        admin.ResetPasswordToken = resetToken;
        admin.ResetPasswordExpireTime = DateTime.Now.AddHours(1);

        // Save
        await _context.SaveChangesAsync();

        // Send email
        var resetPasswordUrl = $"https://localhost:7100/Auth/ResetPassword?resetToken={resetToken}";
        await _mailSender.SendResetPasswordMail(admin.Account, resetPasswordUrl);

        return result.Success();
    }

    private static string GenerateToken()
    {
        var byteArr = new byte[32];
        RandomNumberGenerator.Fill(byteArr);
        return Convert.ToBase64String(byteArr);
    }

    public async Task<Result<string>> GetAccountByResetToken(string resetToken)
    {
        Result<string> result = new();

        var admin = await _context.Admins
            .Where(a => a.ResetPasswordToken == resetToken)
            .FirstOrDefaultAsync();

        if (admin is null)
        {
            return result.NotFound("Token not found");
        }

        result.Data = admin.Account;

        return result.Success();
    }

    public async Task<Result> ResetPassword(ResetPasswordViewModel model)
    {
        Result result = new();

        // Query
        var admin = await _context.Admins
            .Where(a => a.ResetPasswordToken == model.ResetPasswordToken)
            .FirstOrDefaultAsync();

        // Not found
        if (admin is null)
        {
            return result.NotFound("Token not found");
        }

        // Check if expired
        if (admin.ResetPasswordExpireTime.IsBefore(DateTime.Now))
        {
            return result.BadRequest("Token expired");
        }

        // Reset password
        admin.Password = model.NewPassword;
        admin.ResetPasswordToken = null;
        admin.ResetPasswordExpireTime = null;
        admin.UpdatedAt = DateTime.Now;

        // Save
        await _context.SaveChangesAsync();

        return result.Success();
    }
}
