﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Entities;

[Index(nameof(Name), IsUnique = true)]
[GenerateAutoFilter("XClaim.Web.Server.Filters")]
public class BankEntity : BaseEntity {
    [MaxLength(128)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SwiftCode { get; set; } = string.Empty;
    public bool Active { get; set; }
}