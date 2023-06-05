using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nextended.Core.Extensions;
using XClaim.Common.Dtos;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Helpers;

namespace XClaim.Web.Server.Modules.PaymentModule;

public sealed class PaymentService : GenericService<ServerContext, PaymentEntity, PaymentResponse>, IPaymentService {
    
    private readonly IdentityHelper _identity;
    
    public PaymentService(ServerContext ctx, IMapper mapper, ILogger<PaymentService> logger, IdentityHelper identity) : base(ctx, mapper, logger) {
        _identity = identity;
    }

    new public async Task<PagedResponse<List<PaymentResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var id = await _identity.GetId();
        var result = new PagedResponse<List<PaymentResponse>>();
        var query = _ctx.Payments
        .Where(x => x.OwnerId == id)
        .Include(x => x.CreatedBy);
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
                       .Include(x => x.CreatedBy)
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

    private static PaymentStateResponse TransformToPaymentState(PaymentEntity x) =>
    new PaymentStateResponse {
        Id = x.Id,
        OwnerId = x.OwnerId,
        Owner = $"{x.Owner!.FirstName} {x.Owner!.LastName}",
        Description = x.Description ?? string.Empty,
        Amount = x.Amount,
        Count = x.Claims.Count,
        Notes = x.Notes ?? string.Empty,
        CreatedBy = $"{x.CreatedBy!.FirstName} {x.CreatedBy!.LastName}",
        CreatedAt = x.CreatedAt,
    };
    
    public async Task<PagedResponse<List<PaymentStateResponse>>> GetAllTransactionAsync(PaymentFilter responseFilter) {
        var response = new PagedResponse<List<PaymentStateResponse>>();
        try {
            var companyId = await _identity.GetCompanyId();
            var query = _ctx.Payments
            .Where(x => x.CompanyId == companyId)
            .Include(x => x.Owner )
            .Include(x => x.Claims)
            .Include(x => x.CreatedBy)
            .Select(x => TransformToPaymentState(x));
            
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var filter = new PaginationFilter {
                Page = responseFilter.Page,
                PerPage = responseFilter.PerPage
            };
            response = new PagedResponse<List<PaymentStateResponse>>(data, count, filter) {
                Succeeded = true
            };
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }
        
        return response;
    }
    
    public async Task<Response<PaymentStateResponse?>> GetTransactionByIdAsync(Guid id) {
        var response = new Response<PaymentStateResponse?>();
        try {
            var data = await _ctx.Payments.Where(x => x.Id == id)
                       .Include(x => x.CreatedBy)
                       .Include(x => x.Claims)
                       .Select(x => TransformToPaymentState(x))
                       .FirstOrDefaultAsync();
            response.Data = data;
            response.Succeeded = data != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    public async Task<Response<PaymentStateResponse>> CreateTransactionAsync(PaymentResponse value, List<Guid> claims) {
        var response = new Response<PaymentStateResponse>();
        try {
            var item = value.MapTo<PaymentEntity>();
            item.CreatedById = await _identity.GetId();
            item.CompanyId = await _identity.GetCompanyId();
            var result = await _ctx.Payments.AddAsync(item);
            var paymentId = result.Entity.Id;
            await _ctx.SaveChangesAsync();
            await _ctx.Claims.Where(x => claims.Contains(x.Id))
            .ExecuteUpdateAsync(dt => dt.SetProperty(d => d.PaymentId, paymentId));
            response.Data = TransformToPaymentState(item);
            response.Succeeded = true;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    public async Task<Response<PaymentStateResponse>> UpdateTransactionAsync(Guid id, PaymentResponse value, List<Guid> claims) {
        var response = new Response<PaymentStateResponse>();
        try {
            var item = value.MapTo<PaymentEntity>();
            _ctx.Payments.Update(item);
            await _ctx.SaveChangesAsync();
            await _ctx.Claims.Where(x => claims.Contains(x.Id))
            .ExecuteUpdateAsync(dt => dt.SetProperty(d => d.PaymentId, item.Id));
            response.Data = TransformToPaymentState(item);
            response.Succeeded = true;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    public async Task<Response<bool>> ConfirmAsync(Guid id) {
        var response = new Response<bool>();
        try {
            await _ctx.Payments.Where(x => x.Id == id)
            .ExecuteUpdateAsync(dt => dt.SetProperty(d => d.ConfirmedAt, DateTime.Now));
            response.Data = true;
            response.Succeeded = true;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    public async Task<Response<List<PaymentStateResponse>>> RangedConfirmAsync(List<Guid> ids) {
        var response = new Response<List<PaymentStateResponse>>();
        
        throw new NotImplementedException();
    }

    public async Task<Response<PaymentStateResponse?>> CancelAsync(Guid id) {
        var response = new Response<PaymentResponse>();
        
        throw new NotImplementedException();
    }
    
    public async Task<PagedResponse<List<FileResponse>>> GetFileAsync(Guid paymentId, PaginationFilterBase requestFilter) {
        var response = new PagedResponse<List<FileResponse>>();
        try {
            var query = _ctx.Payments.Where(x => x.Id == paymentId)
            .ApplyFilter(requestFilter)
            .Include(x => x.Files)
            .Select(x => x.Files);
            var count = await query.CountAsync();
            var data = await query.ToListAsync();
            var filter = requestFilter.MapTo<PaginationFilter>();
            var result = data.MapTo<List<FileResponse>>();
            response = new PagedResponse<List<FileResponse>>(result, count, filter) {
                Succeeded = true
            };
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }
        
        return response;
    }
    
    public async Task<PagedResponse<List<CommentResponse>>> GetCommentAsync(Guid paymentId, PaginationFilterBase requestFilter) {
        var response = new PagedResponse<List<CommentResponse>>();
        try {
            var query = _ctx.Payments.Where(x => x.Id == paymentId)
            .ApplyFilter(requestFilter)
            .Include(x => x.Comments)
            .Select(x => x.Comments);
            var count = await query.CountAsync();
            var data = await query.ToListAsync();
            var filter = requestFilter.MapTo<PaginationFilter>();
            var result = data.MapTo<List<CommentResponse>>();
            response = new PagedResponse<List<CommentResponse>>(result, count, filter) {
                Succeeded = true
            };
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }
        
        return response;
    }
}