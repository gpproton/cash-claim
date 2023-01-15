using XClaim.Common.Dtos;
using XClaim.Common.Service;

namespace XClaim.Common.HTTP;

public class EventService : IEventService {
    
    private readonly IHttpService _http;
    public EventService(IHttpService http) {
        _http = http;
    }

    public async Task<List<EventResponse>> GetAllAsync() {
        return await _http.Get<List<EventResponse>>("api/v1/event" + "?Page=1&PerPage=25&SortBy=Ascending&CombineWith=Or");
    }
    
    public async Task<EventResponse> GetByIdAsync(Guid id) {
        return await _http.Get<EventResponse>($"api/v1/event/{id}");
    }
}