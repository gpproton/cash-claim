using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class CategoryEntity : BaseEntity {
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Icon { get; set; }
}