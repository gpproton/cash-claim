using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Entities;

public sealed class FileEntity : TimedEntity {
    [MaxLength(256)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(1024)]
    public string? Path { get; set; }
    [MaxLength(8)]
    public string? Extension { get; set; }
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public ClaimEntity? Claim { get; set; }
    public Guid? ClaimId { get; set; }
    public PaymentEntity? Payment { get; set; }
    public Guid? PaymentId { get; set; }
}