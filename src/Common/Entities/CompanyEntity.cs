using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class CompanyEntity : BaseEntity {
    [MaxLength(64)]
    public string ShortName { get; set; } = String.Empty;
    [MaxLength(128)]
    public string FullName { get; set; } = String.Empty;
    [Required]
    [MaxLength(256)]
    public string? Email { get; set; }
    public UserEntity? Manager { get; set; }
    public Guid? ManagerId { get; set; }
    public ICollection<UserEntity>? Members { get; set; }
}