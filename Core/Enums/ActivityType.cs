using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

public enum ActivityType
{
    [Display(Name="一般")]
    [Description("一般")]
    General = 1,
    [Display(Name = "外開連結")]
    [Description("外開連結")]
    OpenLink,
}