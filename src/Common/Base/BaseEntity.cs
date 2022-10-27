using System.ComponentModel.DataAnnotations;

namespace XClaim.Common.Base;

public abstract class BaseEntity
{
    [Key]
    protected Guid Id { get; set; } = Guid.NewGuid();
    protected DateTime CreatedAt { get; set; } = DateTime.Now;
    protected DateTime? DeletedAt { get; set; }
}
