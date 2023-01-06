namespace XClaim.Common.Base;

public interface IBaseEntity {
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}