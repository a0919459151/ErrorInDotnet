using System.ComponentModel;

namespace Core.Enums;

public enum ActivityType
{
    [Description("一般")]
    General = 1,
    [Description("外開連結")]
    OpenLink,
}