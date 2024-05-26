using CMS.Contracts.Auth;

namespace CMS.Services.Interfaces;

public interface IAuthService
{
    Task<Result> Login(LoginViewModel model);

    Task<Result> ForgetPassword(ForgetPasswordViewModel model);

    Task<Result> GetAccountByResetToken(string resetToken);

    Task<Result> ResetPassword(ResetPasswordViewModel model);
}
