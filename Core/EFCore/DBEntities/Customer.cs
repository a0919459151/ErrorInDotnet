using Core.EFCore.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Core.EFCore.DBEntities;

[Comment("前台使用者")]
public class Customer : FullUpdatableEntity
{
    [StringLength(100)]
    [Comment("名稱")]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    [Comment("帳號")]
    public string Account { get; set; } = null!;

    [StringLength(100)]
    [Comment("密碼")]
    public string Password { get; set; } = null!;
}
