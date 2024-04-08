using Backend.Contracts.Auth;

namespace Backend.Services.Interfaces;

public interface IAuthService
{
    // Login
    Task<LoginResponseDto> Login(LoginRequestDto request);

    // Refresh token
    Task<RefreshTokenResponseDto> Refresh(RefreshTokenRequestDto request);

    // Logout
    Task Logout();
}
