using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class Bank : BaseResponse {
    public Bank(string name) {
        Name = name;
    }

    public string Name { get; set; }
}