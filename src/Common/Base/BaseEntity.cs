using System.ComponentModel.DataAnnotations;

namespace XClaim.Common.Base;

public abstract class BaseEntity : IBaseEntity {
    [Key, Required] public Guid Id { get; set; }
}