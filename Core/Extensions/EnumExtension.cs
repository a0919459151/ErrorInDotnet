using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Core.Extensions;

/// <summary>
/// EnumExtension
/// </summary>
public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        var descriptionAttribute = value
            .GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()?
            .GetCustomAttribute<DescriptionAttribute>();

        return descriptionAttribute == null ? string.Empty : descriptionAttribute.Description;
    }

    public static string GetDisplayName(this Enum value)
    {
        return value
            .GetType()
            .GetMember(value.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName() ?? string.Empty;
    }
}
