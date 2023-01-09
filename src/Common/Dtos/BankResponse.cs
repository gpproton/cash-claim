using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class BankResponse : BaseResponse {
    public BankResponse(string name) {
        Name = name;
    }

    public string Name { get; set; }
}