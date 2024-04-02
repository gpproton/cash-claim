using System.ComponentModel.DataAnnotations;
using CashClaim.Common.Base;

namespace XClaim.Web.Server.Entities;

public sealed class CompanyEntity : TimedEntity {
    public bool Active { get; set; }
    [MaxLength(64)]
    public string ShortName { get; set; } = String.Empty;
    [MaxLength(128)]
    public string FullName { get; set; } = String.Empty;
    [Required]
    [MaxLength(256)]
    public string AdminEmail { get; set; } = String.Empty;
    public UserEntity? Manager { get; set; }
    public Guid? ManagerId { get; set; }
    public ICollection<UserEntity> Members { get; set; } = default!;
}