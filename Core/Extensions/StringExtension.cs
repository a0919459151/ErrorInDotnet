namespace Core.Extensions;

/// <summary>
/// string 擴展方法
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// 截斷字串
    /// </summary>
    /// <param name="input">輸入字串</param>
    /// <param name="maxLength">字串截斷長度</param>
    /// <returns></returns>
    public static string Truncate(this string input, int maxLength)
    {
        if (input.Length <= maxLength)
        {
            return input;
        }

        var truncationString = "...";
        return input.Truncate(maxLength, truncationString);
    }

    /// <summary>
    /// 截斷字串 overload
    /// </summary>
    /// <param name="input">輸入字串</param>
    /// <param name="maxLength">字串截斷長度</param>
    /// <param name="truncationString">替代字串</param>
    /// <returns></returns>
    public static string Truncate(this string input, int maxLength, string truncationString)
    {
        if (input.Length <= maxLength)
        {
            return input;
        }

        return $"{input.Substring(0, maxLength)}{truncationString}";
    }

    /// <summary>
    /// 姓名遮罩 (英文小寫'o'遮第二個字元)
    /// </summary>
    /// <param name="originalName">原始姓名</param>
    /// <returns></returns>
    public static string MaskName(this string originalName)
    {
        if (originalName.Length <= 1) return originalName;

        var maskNameFormat = "{0}{1}{2}";
        var maskChar = 'o';
        var maskCharIndex = 1;
        var substring1 = originalName.Substring(0, maskCharIndex);
        var substring2 = originalName.Substring(maskCharIndex + 1);
        return string.Format(maskNameFormat, substring1, maskChar, substring2);
    }
}
