using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class FileEntity : BaseEntity {
    [MaxLength(256)]
    public string? Name { get; set; }
    [Required]
    [MaxLength(1024)]
    public string? Path { get; set; }
    [MaxLength(8)]
    public string? Extension { get; set; }
    public ClaimEntity? Claim { get; set; }
    public Guid? ClaimId { get; set; }
}