using XClaim.Common.Base;

namespace XClaim.Common.Entities;

internal class Category : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }

}
