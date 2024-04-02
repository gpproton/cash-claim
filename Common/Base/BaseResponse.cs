namespace CashClaim.Common.Base;

public abstract class BaseResponse {
    public Guid? Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}