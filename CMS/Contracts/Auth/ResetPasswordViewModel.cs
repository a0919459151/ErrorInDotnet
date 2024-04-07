using System.ComponentModel.DataAnnotations;

namespace CMS.Contracts.Auth;

public class ResetPasswordViewModel
{
    [Display(Name = "New password")]
    [Required]
    [StringLength(50)]
    public string NewPassword { get; set; } = null!;

    [Required]
    public string ResetPasswordToken { get; set; } = null!;
}
