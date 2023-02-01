using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public class SettingResponse {
    public UserResponse? Owner { get; set; }
    public Guid OwnerId { get; set; }
    public bool DarkMode { get; set; }
    public AppLanguage Language { get; set; } = AppLanguage.English;
}