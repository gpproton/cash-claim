using System.ComponentModel.DataAnnotations;

namespace CashClaim.Common.Base;

public abstract class BaseEntity : IBaseEntity {
    [Key, Required] public Guid Id { get; set; }
}