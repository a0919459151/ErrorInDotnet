namespace Core.EFCore.BaseEntities;

public class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;
}
