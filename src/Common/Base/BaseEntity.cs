using System.ComponentModel.DataAnnotations;

namespace XClaim.Common.Base;

public abstract class BaseEntity {
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; }
}