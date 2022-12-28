using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class Attachment : BaseEntity {
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public Claim Claim { get; set; }
}