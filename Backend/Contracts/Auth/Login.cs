using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Auth;

public class LoginRequestDto
{
    [Required]
    public string Account { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}

public class LoginResponseDto
{
    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}