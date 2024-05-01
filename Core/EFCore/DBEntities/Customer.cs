using System.ComponentModel.DataAnnotations;

namespace Core.EFCore.DBEntities;

[Comment("前台使用者")]
public class Customer : BaseEntity
{
    [StringLength(100)]
    [Comment("名稱")]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    [Comment("帳號")]
    public string Account { get; set; } = null!;

    [StringLength(100)]
    [Comment("密碼 hash")]
    public string PasswordHash { get; set; } = null!;

    [StringLength(100)]
    [Comment("密碼 salt")]
    public string PasswordSalt { get; set; } = null!;

    [StringLength(100)]
    [Comment("刷新令牌")]
    public string? RefreshToken { get; set; }

    [Comment("刷新令牌到期時間")]
    public DateTime? RefreshTokenExpireAt { get; set; }
}
