using System.ComponentModel.DataAnnotations;

namespace CMS.Contracts.Auth;

public class LoginViewModel
{
    [Required]
    public string Account { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
