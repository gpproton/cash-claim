using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class TeamEntity : BaseEntity {
    public string Name { get; set; } = string.Empty;
    public CompanyEntity? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public UserEntity? Manager { get; set; }
    public Guid? ManagerId { get; set; }
    public ICollection<UserEntity>? Members { get; set; }
}