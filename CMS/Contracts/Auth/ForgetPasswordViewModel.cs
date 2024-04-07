using System.ComponentModel.DataAnnotations;

namespace CMS.Contracts.Auth;

public class ForgetPasswordViewModel
{
    [Display(Name = "Account")]
    [Required]
    [StringLength(50)]
    public string Account { get; set; } = null!;
}
