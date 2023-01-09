using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class FileResponse : BaseResponse {
    public FileResponse(string? name, string? path, string? extension) {
        Name = name;
        Path = path;
        Extension = extension;
    }

    public string? Name { get; set; }
    public string? Path { get; set; }
    public string? Extension { get; set; }
}