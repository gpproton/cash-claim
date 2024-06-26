﻿using CashClaim.Common.Base;

namespace CashClaim.Common.Dtos;

public class CompanyResponse : BaseResponse {
    public string ShortName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string AdminEmail { get; set; } = string.Empty;
    public UserResponse? Manager { get; set; }
    public Guid? ManagerId { get; set; }
    public bool Active { get; set; }
}