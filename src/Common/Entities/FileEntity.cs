using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class FileEntity : BaseEntity {
    public string? Name { get; set; }
    public string Path { get; set; }
    public string? Extension { get; set; }
    public ClaimEntity? Claim { get; set; }
}