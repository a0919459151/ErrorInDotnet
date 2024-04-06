﻿namespace Core.EFCore.BaseEntities;

public class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public DateTime? DeletedAt { get; set; }

    public int? UpdaterId { get; set; }
}
