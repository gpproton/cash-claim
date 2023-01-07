﻿using System.ComponentModel.DataAnnotations;

namespace XClaim.Common.Base;

public abstract class BaseEntity : IBaseEntity {
    [Key, Required] public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}