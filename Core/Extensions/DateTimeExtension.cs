namespace Core.Extensions;

/// <summary>
/// DateTimeExtension
/// </summary>
public static class DateTimeExtension
{
    /// <summary>
    /// 之前
    /// </summary>
    /// <param name="date">輸入時間</param>
    /// <param name="compareDate">比較時間</param>
    /// <returns></returns>
    public static bool IsBefore(this DateTime? date, DateTime? compareDate)
    {
        if (date == null || compareDate == null) return false;

        return date < compareDate;
    }

    /// <summary>
    /// 之前
    /// </summary>
    /// <param name="date">輸入時間</param>
    /// <param name="compareDate">比較時間</param>
    /// <returns></returns>
    public static bool IsBeforeOrEqual(this DateTime? date, DateTime? compareDate)
    {
        if (date == null || compareDate == null) return false;
        return date <= compareDate;
    }

    /// <summary>
    /// 之後
    /// </summary>
    /// <param name="date">輸入時間</param>
    /// <param name="compareDate">比較時間</param>
    /// <returns></returns>
    public static bool IsAfter(this DateTime? date, DateTime? compareDate)
    {
        if (date == null || compareDate == null) return false;
        return date > compareDate;
    }

    /// <summary>
    /// 之後
    /// </summary>
    /// <param name="date">輸入時間</param>
    /// <param name="compareDate">比較時間</param>
    public static bool IsAfterOrEqual(this DateTime? date, DateTime? compareDate)
    {
        if (date == null || compareDate == null) return false;
        return date >= compareDate;
    }

    /// <summary>
    /// 在期間內
    /// </summary>
    /// <param name="date">輸入時間</param>
    /// <param name="startDate">開始時間</param>
    /// <param name="endDate">結束時間</param>
    /// <returns></returns>
    public static bool IsBetween(this DateTime? date, DateTime? startDate, DateTime? endDate)
    {
        if (date == null || startDate == null || endDate == null) return false;
        return date >= startDate && date <= endDate;
    }

    /// <summary>
    /// 在期間內 
    /// </summary>
    /// <param name="date">輸入時間</param>
    /// <param name="startDate">開始時間</param>
    /// <param name="endDate">結束時間</param>
    /// <returns></returns>
    public static bool IsBetweenOrEqual(this DateTime? date, DateTime? startDate, DateTime? endDate)
    {
        if (date == null || startDate == null || endDate == null) return false;
        return date >= startDate && date <= endDate;
    }
}
