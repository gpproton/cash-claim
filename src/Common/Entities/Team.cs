using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class Team : BaseEntity {
    public string Name { get; set; }
    public Team? Manager { get; set; }
}