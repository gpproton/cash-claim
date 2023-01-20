using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class BankAccountResponse : BaseResponse {
    public string FullName { get; set; } = string.Empty;
    public BankResponse? Bank { get; set; }
    public UserResponse? Owner { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}