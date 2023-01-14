using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class DomainResponse : BaseResponse {
    public string Address { get; set; } = string.Empty;
}