using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Entities;

public sealed class CategoryEntity : TimedEntity {
    [MaxLength(128)]
    public string Name { get; set; } = string.Empty;
    public CompanyEntity? Company { get; set; }
    public Guid? CompanyId { get; set; }
    [MaxLength(1024)]
    public string? Description { get; set; } = string.Empty;
    public bool Active { get; set; }
    [MaxLength(64)]
    public string? Icon { get; set; } = string.Empty;
}