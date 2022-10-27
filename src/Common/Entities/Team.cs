using XClaim.Common.Base;

namespace XClaim.Common.Entities;

internal class Team : BaseEntity
{
    public string Name { get; set; }
    public Team? Manager { get; set; }
}
