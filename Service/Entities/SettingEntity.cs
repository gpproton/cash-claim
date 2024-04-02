using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace XClaim.Web.Server.Entities;

public class SettingEntity : TimedEntity {
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public bool DarkMode { get; set; }
    public AppLanguage Language { get; set; } = AppLanguage.English;
}