using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public interface ITeamService {
    Task<PagedResponse<List<TeamResponse>>> GetAllAsync(object? query = null);

    Task<Response<TeamResponse>> GetByIdAsync(Guid id);

    Task<Response<TeamResponse>> CreateAsync(TeamResponse team);

    Task<Response<TeamResponse>> UpdateAsync(TeamResponse team);

    Task<Response<TeamResponse>> ArchiveAsync(Guid id);

    Task<Response<List<TeamResponse>>> ArchiveRangeAsync(List<Guid> ids);
}