using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class CategoryEntity : BaseEntity {
    public string Name { get; set; } = string.Empty;
    [Required]
    public CompanyEntity? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}