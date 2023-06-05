using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class TransferRequestItem : BaseResponse {
    public string? User { get; set; }
    public Guid? UserId { get; set; }
    public string? Company { get; set; }
    public string? PreviousCompany { get; set; }
    public string? Email { get; set; }
    public bool Completed { get; set; }
}