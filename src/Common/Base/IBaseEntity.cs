namespace XClaim.Common.Base;

public interface IBaseEntity {
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}