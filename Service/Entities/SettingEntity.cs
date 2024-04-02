using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace CashClaim.Service.Entities;

public class SettingEntity : TimedEntity {
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public bool DarkMode { get; set; }
    public AppLanguage Language { get; set; } = AppLanguage.English;
}