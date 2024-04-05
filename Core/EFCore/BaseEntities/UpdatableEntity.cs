using Core.EFCore.BaseEntities;

namespace Core.EFCore.Common;

public class UpdatableEntity : BaseEntity
{
    public DateTime UpdateAt { get; set; } = DateTime.Now;

    public int UpdaterId { get; set; }
}
