using XClaim.Common.Dtos;

namespace XClaim.Common.HTTP;

public interface IEventService {
    Task<List<EventResponse>> GetAllAsync();
    Task<EventResponse> GetByIdAsync(Guid id);
}