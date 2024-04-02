namespace XClaim.Common.Base;

public abstract class TimedEntity : ITimedEntity {
    new public DateTime CreatedAt { get; set; }
    new public DateTime? ModifiedAt { get; set; }
    new public DateTime? DeletedAt { get; set; }
}