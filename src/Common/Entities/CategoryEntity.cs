using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class CategoryEntity : BaseEntity {
    public string Name { get; set; } = string.Empty;
    public CompanyEntity? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? Icon { get; set; } = string.Empty;
}