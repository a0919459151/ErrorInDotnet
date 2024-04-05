using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts.Auth;

/// <summary>
/// Login request DTO
/// </summary>
public class LoginRequestDto
{
    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
