using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public record Bank : BaseResponse {
    public Bank(string name) {
        Name = name;
    }

    public string Name { get; set; } = string.Empty;
}