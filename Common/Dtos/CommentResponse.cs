﻿using CashClaim.Common.Base;

namespace CashClaim.Common.Dtos;

public class CommentResponse : BaseResponse {
    public ClaimResponse? Claim { get; set; }
    public PaymentResponse? Payment { get; set; }
    public UserResponse? Owner { get; set; }
    public string Content { get; set; } = string.Empty;
}