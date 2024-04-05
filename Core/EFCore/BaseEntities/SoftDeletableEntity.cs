namespace Core.EFCore.BaseEntities;

public class SoftDeletableEntity
{
    public DateTime? DeleteAt { get; set; }
}
