using Core.EFCore.BaseEntities;

namespace Core.EFCore.Common;

public class FullUpdatableEntity : BaseEntity
{
    public DateTime UpdateAt { get; set; } = DateTime.Now;

    public DateTime? DeleteAt { get; set; }

    public int UpdaterId { get; set; }
}
