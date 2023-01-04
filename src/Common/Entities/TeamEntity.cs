using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class TeamEntity : BaseEntity {
    public string Name { get; set; } = string.Empty;
    // public UserEntity? Manager { get; set; }
}