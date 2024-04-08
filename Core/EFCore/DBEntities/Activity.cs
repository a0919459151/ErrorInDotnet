using System.ComponentModel.DataAnnotations;

namespace Core.EFCore.DBEntities;

[Comment("活動")]
public class Activity : BaseEntity
{
    [StringLength(100)]
    [Comment("活動名稱")]
    public string ActivityName { get; set; } = null!;

    [Comment("活動類型")]
    public ActivityType ActivityTypeId { get; set; }


    // 活動類別
    public int? ActivityCategoryId { get; set; }
    public ActivityCategory? ActivityCategory { get; set; }
}
