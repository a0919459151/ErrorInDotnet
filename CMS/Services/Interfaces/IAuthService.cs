using CMS.Contracts.Auth;
using Core.Results;

namespace CMS.Services.Interfaces;

public interface IAuthService
{
    Task<Result> Login(LoginViewModel model);
}
