namespace Core.EFCore.BaseEntities;

public class BaseEntity
{
    [Comment("ID")]
    public int Id { get; set; }

    [Comment("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Comment("UpdatedAt")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Comment("DeletedAt")]
    public DateTime? DeletedAt { get; set; }

    [Comment("UpdaterId")]
    public int? UpdaterId { get; set; }
}
