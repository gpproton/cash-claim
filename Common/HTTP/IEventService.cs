using CashClaim.Common.Dtos;

namespace CashClaim.Common.HTTP;

public interface IEventService {
    Task<List<EventResponse>> GetAllAsync();
    Task<EventResponse> GetByIdAsync(Guid id);
}