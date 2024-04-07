using Core.EFCore.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Core.EFCore.DBEntities;

[Comment("後台使用者")]
public class Admin : BaseEntity
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

    [StringLength(100)]
    [Comment("重設密碼權杖")]
    public string? ResetPasswordToken { get; set; }

    [Comment("重設密碼過期時間")]
    public DateTime? ResetPasswordExpireTime { get; set; }
}
