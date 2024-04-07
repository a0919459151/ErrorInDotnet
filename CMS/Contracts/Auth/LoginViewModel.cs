using System.ComponentModel.DataAnnotations;

namespace CMS.Contracts.Auth;

public class LoginViewModel
{
    [Display(Name = "Account")]
    [Required]
    [StringLength(50)]
    public string Account { get; set; } = null!;

    [Display(Name = "Password")]
    [Required]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me")]
    [Required]
    public bool IsRememberMe { get; set; }
}
