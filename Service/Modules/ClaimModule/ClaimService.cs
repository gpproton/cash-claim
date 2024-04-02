using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Nextended.Core.Extensions;
using CashClaim.Common.Dtos;
using CashClaim.Common.Enums;
using CashClaim.Common.Helpers;
using CashClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Helpers;
using XClaim.Web.Server.Modules.UserModule;

namespace XClaim.Web.Server.Modules.ClaimModule;

public sealed class ClaimService : GenericService<ServerContext, ClaimEntity, ClaimResponse>, IClaimService {
    private readonly IdentityHelper _identity;
    private readonly ClaimStateResolver _stateResolver;
    public ClaimService(ServerContext ctx, IMapper mapper, ILogger<ClaimService> logger, IdentityHelper identity, ClaimStateResolver stateResolver) : base(ctx, mapper, logger) {
        _identity = identity;
        _stateResolver = stateResolver;
    }

    private static Task<IIncludableQueryable<ClaimEntity, CurrencyEntity?>> ClaimPersonalQuery(IQueryable<ClaimEntity> queryable) {
        return Task.FromResult(queryable
        .Include(x => x.Owner)
        .Include(x => x.Category)
        .Include(x => x.Currency));
    }

    new public async Task<PagedResponse<List<ClaimResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var id = await _identity.GetId();
        var result = new PagedResponse<List<ClaimResponse>>();
        var query = (await ClaimPersonalQuery(_ctx.Claims))
        .Where(x => x.OwnerId == id);
        try {
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var response = _mapper.Map<List<ClaimResponse>>(data);
            var filter = responseFilter.MapTo<PaginationFilter>();
            result = new PagedResponse<List<ClaimResponse>>(response, count, filter) {
                Succeeded = true
            };
        } catch (Exception e) {
            result.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return result;
    }

    new public async Task<Response<ClaimResponse?>> GetByIdAsync(Guid id) {
        var response = new Response<ClaimResponse?>();
        try {
            var item = await (await ClaimPersonalQuery(_ctx.Claims))
                       .Where(x => x.Id == id)
                       .Include(x => x.Payment)
                       .Include(x => x.Currency)
                       .FirstOrDefaultAsync();
            var data = _mapper.Map<ClaimResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    new public async Task<Response<ClaimResponse>> CreateAsync(ClaimResponse value) {
        var user = await _identity.GetUser();
        var response = new Response<ClaimResponse>();
        try {
            var item = value.MapTo<ClaimEntity>();
            item.OwnerId = await _identity.GetId();
            item.CompanyId = await _identity.GetCompanyId();
            await _ctx.Claims.AddAsync(item);
            await _ctx.SaveChangesAsync();
            if (user is { Permission: <= UserPermission.Finance }) {
                await this.ReviewValidateAsync(item.Id,  ClaimStatus.None, new CommentResponse { Content = "Confirmed by default."});
            }
            var data = _mapper.Map<ClaimResponse>(item);
            response = new Response<ClaimResponse>(data!) {
                Succeeded = data != null
            };
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }

    private async Task<IQueryable<ClaimEntity>> ResolveClaimEntity(bool skipFilter = false) {
        var user = await _identity.GetUser();
        var userId = await _identity.GetId();
        var company = await _identity.GetCompanyId();
        var users = await _identity.GetTeamMemberId();
        IQueryable<ClaimEntity> filtered;
        var query = _ctx.Claims;
        if (!skipFilter) {
            switch (user!.Permission) {
                case UserPermission.System:
                    filtered = query.Where(x => x.OwnerId != userId)
                    .Where(x => x.PaymentId == null);
                    break;
                case UserPermission.Administrator:
                    filtered = query.Where(x => x.OwnerId != userId)
                    .Where(x => x.PaymentId == null)
                    .Where(x => x.CompanyId == company)
                    .Where(x => x.Status >= ClaimStatus.Confirmed);
                    break;
                case UserPermission.Finance:
                    filtered = query.Where(x => x.OwnerId != userId)
                    .Where(x => x.PaymentId == null)
                    .Where(x => x.CompanyId == company)
                    .Where(x => x.Status >= ClaimStatus.Reviewed);
                    break;
                case UserPermission.Lead:
                    filtered = query.Where(x => x.CompanyId == company && users.Contains(x.OwnerId!.Value))
                    .Where(x => x.OwnerId != userId)
                    .Where(x => x.PaymentId == null)
                    .Where(x => x.Status >= ClaimStatus.Pending);
                    break;
                case UserPermission.Cashier:
                case UserPermission.Standard:
                case UserPermission.Anonymous:
                default:
                    filtered = query.Where(x => false);
                    break;
            }
        } else {
            filtered = query.Where(x => x.Status != ClaimStatus.Pending);
        }
        
        return filtered.Include(x => x.Owner)
        .Include(x => x.Category)
        .Include(x => x.Payment)
        .Include(x => x.Currency);
    }

    public async Task<PagedResponse<List<ClaimStateResponse>>> GetReviewAllAsync(ClaimFilter responseFilter) {
        var response = new PagedResponse<List<ClaimStateResponse>>();
        try {
            var query = await this.ResolveClaimEntity();
            async Task<ClaimStateResponse> TransformEntity(ClaimEntity x) {
                var state = _stateResolver.InitializeState(x);
                return await state.Resolve();
            }

            var result = query.ApplyFilter(responseFilter);
            var count = await result.CountAsync();
            var db = await result.ToListAsync();
            var data = db.Select(x => TransformEntity(x).Result).ToList();
            var filter = responseFilter.MapTo<PaginationFilter>();
            response = new PagedResponse<List<ClaimStateResponse>>(data, count, filter) {
                Succeeded = true
            };
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }

    public async Task<Response<ClaimStateResponse?>> GetReviewByIdAsync(Guid id) {
        var response = new Response<ClaimStateResponse?>();
        Func<ClaimEntity, Task<ClaimStateResponse>> transformEntity = async x => {
            var state = _stateResolver.InitializeState(x);
            return await state.Resolve();
        };
        try {
            var user = await _identity.GetUser();
            if(user?.Id != null) {
                var query = await this.ResolveClaimEntity(true);
                var data = await query.Where(x => x.Id == id)
                .Select(x => transformEntity(x).Result).FirstOrDefaultAsync();
                response.Data = data;
                response.Succeeded = data != null;
            }
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }

    public async Task<Response<ClaimStateResponse?>> ReviewValidateAsync(Guid id, ClaimStatus action, CommentResponse? comment) {
        var response = new Response<ClaimStateResponse?>();
        var userId = await _identity.GetId();
        try {
            var item = await (await ClaimPersonalQuery(_ctx.Claims))
                       .Where(x => x.Id == id)
                       .Include(x => x.Payment)
                       .Include(x => x.Files)
                       .FirstOrDefaultAsync();
            if (item is null) return response;
            var value = await _stateResolver.InitializeState(item).Transform(action);
            _mapper.Map(value, item);
            if (comment != null) {
                _ctx.Comments.Add(new CommentEntity {
                    OwnerId = userId,
                    ClaimId = item.Id,
                    Content = comment.Content
                });
            }
            _ctx.Update(item);
            await _ctx.SaveChangesAsync();
            response.Data = await _stateResolver.InitializeState(value).Resolve();
            response.Succeeded = response.Data  != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    public async Task<PagedResponse<List<UserResponse>>> GetPendingUserAsync(UserFilter requestFilter) {
        var response = new PagedResponse<List<UserResponse>>();
        try {
            var companyId = await _identity.GetCompanyId();
            var claimUsers = await _ctx.Claims.Where(x => x.CompanyId == companyId)
                             .Where(x => x.Status == ClaimStatus.Approved)
                             .Where(x => x.PaymentId == null)
                             .AsNoTracking()
                             .Select(x => x.OwnerId)
                             .Take(55)
                             .ToListAsync();
            var query = _ctx.Users
                .Where(x => claimUsers.Contains(x.Id))
                .ApplyFilter(requestFilter);
            var count = await query.CountAsync();
            var data = await query.ToListAsync();
            var filter = requestFilter.MapTo<PaginationFilter>();
            var result = data.MapTo<List<UserResponse>>();
            response = new PagedResponse<List<UserResponse>>(result, count, filter) {
                Succeeded = true
            };
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }

    public async Task<PagedResponse<List<FileResponse>>> GetFileAsync(Guid claimId, PaginationFilterBase requestFilter) {
        var response = new PagedResponse<List<FileResponse>>();
        try {
            var query = _ctx.Claims.Where(x => x.Id == claimId)
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
    
    public async Task<PagedResponse<List<CommentResponse>>> GetCommentAsync(Guid claimId, PaginationFilterBase requestFilter) {
        var response = new PagedResponse<List<CommentResponse>>();
        try {
            var query = _ctx.Claims.Where(x => x.Id == claimId)
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