namespace XClaim.Common.Base;

public abstract record BaseResponse {
    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}