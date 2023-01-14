using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class BankResponse : BaseResponse {
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
}