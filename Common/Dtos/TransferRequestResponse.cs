using CashClaim.Common.Base;

namespace CashClaim.Common.Dtos;

public class TransferRequestResponse : BaseResponse {
    public UserResponse? User { get; set; }
    public Guid? UserId { get; set; }
    public CompanyResponse? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public bool Completed { get; set; }
}