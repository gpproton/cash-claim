using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class CompanyEntity : BaseEntity {
    public string ShortName { get; set; } = String.Empty;
    public string FullName { get; set; } = String.Empty;
    [Required]
    public string? Email { get; set; }
    public UserEntity? Manager { get; set; }
    public Guid? ManagerId { get; set; }
    public ICollection<UserEntity>? Members { get; set; }
}