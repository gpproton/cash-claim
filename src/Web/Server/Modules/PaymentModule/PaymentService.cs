using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Helpers;

namespace XClaim.Web.Server.Modules.PaymentModule;

public sealed class PaymentService : GenericService<ServerContext, PaymentEntity, PaymentResponse> {
    
    private readonly IdentityHelper _identity;
    
    public PaymentService(ServerContext ctx, IMapper mapper, ILogger<PaymentService> logger, IdentityHelper identity) : base(ctx, mapper, logger) {
        _identity = identity;
    }

    new public async Task<PagedResponse<List<PaymentResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var id = ((await _identity.GetUser())!).Id;
        var result = new PagedResponse<List<PaymentResponse>>();
        var query = _ctx.Payments
        .Where(x => x.DeletedAt == null)
        .Where(x => x.OwnerId == id)
        .Include(x => x.ConfirmedBy);
        try {
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var response = _mapper.Map<List<PaymentResponse>>(data);
            var filter = new PaginationFilter {
                Page = responseFilter.Page,
                PerPage = responseFilter.PerPage
            };
            result = new PagedResponse<List<PaymentResponse>>(response, count, filter) {
                Succeeded = true
            };
        } catch (Exception e) {
            result.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return result;
    }
    
    new public async Task<Response<PaymentResponse?>> GetByIdAsync(Guid id) {
        var response = new Response<PaymentResponse?>();
        try {
            var item = await _ctx.Payments.Where(x => x.Id == id)
                       .Include(x => x.ConfirmedBy)
                       .Include(x => x.Files)
                       .Include(x => x.Claims)
                       .FirstOrDefaultAsync();
            var data = _mapper.Map<PaymentResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    public async Task<PagedResponse<List<PaymentResponse>>> GetPaymentsAsync(PaginationFilterBase responseFilter) => default!;

    public async Task<Response<PaymentResponse?>> CompleteAsync(Guid id) => default!;
}