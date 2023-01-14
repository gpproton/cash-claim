using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class FileResponse : BaseResponse {
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string Extension { get; set; } = string.Empty;
}