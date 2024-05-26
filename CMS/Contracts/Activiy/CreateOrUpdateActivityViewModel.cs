using System.ComponentModel.DataAnnotations;

namespace CMS.Contracts.Activiy;

public class CreateOrUpdateActivityViewModel
{
    public int? Id { get; set; }

    [StringLength(100)]
    [Display(Name = "活動名稱")]
    public string ActivityName { get; set; } = null!;

    [Display(Name = "活動類型")]
    public ActivityType ActivityType { get; set; }
}
