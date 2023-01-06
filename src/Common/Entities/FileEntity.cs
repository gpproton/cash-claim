using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class FileEntity : BaseEntity {
    public string? Name { get; set; }
    [Required]
    public string? Path { get; set; }
    public string? Extension { get; set; }
    public ClaimEntity? Claim { get; set; }
    public Guid? ClaimId { get; set; }
}