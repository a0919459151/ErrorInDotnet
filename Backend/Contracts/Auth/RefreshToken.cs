namespace Backend.Contracts.Auth;

public class RefreshTokenRequestDto
{
    public string RefreshToken { get; set; } = null!;
}

public class RefreshTokenResponseDto
{
    public string AccessToken { get; set; } = null!;
}
