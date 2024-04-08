using CMS.Contracts.Auth;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers;

[AllowAnonymous]
public class AuthController : Controller
{
    private readonly ToasterHelper _toastorHelper;
    private readonly IAuthService _authService;

    public AuthController(
        ToasterHelper toastorHelper,
        IAuthService authService)
    {
        _authService = authService;
        _toastorHelper = toastorHelper;
    }

    // Login page
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    // Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await _authService.Login(model);

        if (!result.IsSuccess)
        {
            _toastorHelper.Error(result.Message);
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    // Forget password page
    public IActionResult ForgetPassword()
    {
        return View(new ForgetPasswordViewModel());
    }

    // Forget password
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
    {
        var result = await _authService.ForgetPassword(model);

        if (!result.IsSuccess)
        {
            _toastorHelper.Error(result.Message);
            return View(model);
        }

        return RedirectToAction(nameof(ResetPasswordEmailSent));
    }

    // Reset password email send
    public IActionResult ResetPasswordEmailSent()
    {
        return View();
    }

    // Reset password page
    public async Task<IActionResult> ResetPassword(string resetToken)
    {
        var accountResult = await _authService.GetAccountByResetToken(resetToken);

        if (!accountResult.IsSuccess)
        {
            _toastorHelper.Error(accountResult.Message);
            return RedirectToAction(nameof(Login));
        }

        // Bring account to view
        ViewBag.Account = accountResult.Data;

        var vm = new ResetPasswordViewModel()
        {
            ResetPasswordToken = resetToken
        };

        return View(vm);
    }

    // Reset password
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        var result = await _authService.ResetPassword(model);

        if (!result.IsSuccess)
        {
            _toastorHelper.Error(result.Message);
            return View(model);
        }

        _toastorHelper.Success("Password reset successfully");
        return RedirectToAction(nameof(Login));
    }

    // Reset password successful page
    public IActionResult ResetPasswordSuccessful()
    {
        return View();
    }

    // Logout
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(Login));
    }
}
