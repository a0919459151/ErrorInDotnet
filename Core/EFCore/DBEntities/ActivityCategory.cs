using System.ComponentModel.DataAnnotations;

namespace Core.EFCore.DBEntities;

[Comment("活動類別")]
public class ActivityCategory :BaseEntity
{
    [StringLength(100)]
    [Comment("類別名稱")]
    public string CategoryName { get; set; } = null!;

    // 活動
    public ICollection<Activity>? Activities { get; set; } = null!;
}
