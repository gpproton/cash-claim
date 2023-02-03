using AutoFilterer.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Enums;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Helpers;

namespace XClaim.Web.Server.Modules.UserModule;

public sealed class UserService : GenericService<ServerContext, UserEntity, UserResponse>, IUserService {
    private readonly IdentityHelper _identity;
    public UserService(ServerContext ctx, IMapper mapper, ILogger<UserService> logger, IdentityHelper identity) : base(ctx, mapper, logger) {
        _identity = identity;
    }
    
    private async Task<Guid?> GetId() {
        var profile = await _identity.GetUser();
        return profile!.Id;
    }
    
    public async Task<Response<UserResponse?>> GetByEmailAsync(string email) {
        var item = await _ctx.Users
                   .Where(x => x.DeletedAt == null)
                   .Where(x => x.Email == email)
                   .Include(x => x.Company)
                   .Include(x => x.Team)
                   .Include(x => x.Currency)
                   .Include(x => x.Setting)
                   .FirstOrDefaultAsync();
        var data = _mapper.Map<UserResponse>(item);

        return new Response<UserResponse?> {
            Data = data,
            Succeeded = data != null
        };
    }
    
    public async Task<Response<UserResponse?>> GetByIdentifierAsync(string? identifier) {
        var item = await _ctx.Users
                   .Where(x => x.DeletedAt == null)
                   .Where(x => x.Identifier == identifier)
                   .Include(x => x.Company)
                   .Include(x => x.Team)
                   .Include(x => x.Currency)
                   .Include(x => x.Setting)
                   .FirstOrDefaultAsync();
        var data = _mapper.Map<UserResponse>(item);

        return new Response<UserResponse?> {
            Data = data,
            Succeeded = data != null
        };
    }

    public async Task<PagedResponse<List<UserResponse>>> GetAllAsync(UserFilter responseFilter) {
        var result = new PagedResponse<List<UserResponse>>();
        try {
            var current = await _identity.GetUser();
            // INFO: Return an error to normal users
            if (current!.Permission > UserPermission.Administrator) return result;
            var isAdmin = current.Permission == UserPermission.Administrator;
            var query = _ctx.Users
            // INFO: Limits admins to their company and haide system mangers.
            .Where(x => !isAdmin || x.CompanyId == current.CompanyId && x.Permission != UserPermission.System )
            .Include(x => x.Company)
            .Include(x => x.Team);
            
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var response = _mapper.Map<List<UserResponse>>(data);
            var filter = new PaginationFilter {
                Page = responseFilter.Page,
                PerPage = responseFilter.PerPage
            };
            result = new PagedResponse<List<UserResponse>>(response, count, filter) {
                Succeeded = true
            };
        }
        catch (Exception e) {
            result.Errors = new[] {
                e.ToString()
            };
            _logger.LogError(e.ToString());
        }

        return result;
    }

    new public async Task<Response<UserResponse?>> GetByIdAsync(Guid id) {
        var response = new Response<UserResponse?>();
        try {
            var item = await _ctx.Users
                       .Where(x => x.Id == id)
                       .Include(x => x.Company)
                       .Include(x => x.Team)
                       .Include(x => x.Currency)
                       .FirstOrDefaultAsync();
            var data = _mapper.Map<UserResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    new public async Task<Response<UserResponse>> CreateAsync(UserResponse value) {
        var response = new Response<UserResponse>();
        try {
            var item = _mapper.Map<UserEntity>(value);
            item.Identifier = _identity.NameIdentifier!;
            item.Active = true;
            var isAdmin = (await _ctx.Users.CountAsync(x => x.Permission == UserPermission.System)) < 1;
            if (isAdmin) item.Permission = UserPermission.System;
            await _ctx.Users.AddAsync(item);
            await _ctx.SaveChangesAsync();
            var data = _mapper.Map<UserResponse>(item);
            response = new Response<UserResponse>(data!) {
                Succeeded = data != null
            };
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }

    private async Task<TransferRequestEntity?> GetTransfer() {
        try {
            var id = await this.GetId();
            if (id == null) return null;
            return await _ctx.TransferRequests.Where(x => x.UserId == id && x.Completed == false)
                   .Include(x => x.User)
                   .AsNoTracking()
                   .FirstOrDefaultAsync();
        }
        catch (Exception) {
            // ignore
        }

        return null;
    }
    
    public async Task<Response<TransferRequestResponse?>> GetTransferAsync() {
        var response = new Response<TransferRequestResponse?>();
        try {
            var transfer = await this.GetTransfer();
            if (transfer != null) {
                var data = _mapper.Map<TransferRequestResponse>(transfer);
                response.Data = data;
            }
            response.Succeeded = true;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    public async Task<Response<TransferRequestResponse>> CreateTransferAsync() {
        var response = new Response<TransferRequestResponse>();
        try {
            var id = await this.GetId();
            if (id != null) {
                var item = new TransferRequestEntity { UserId = id, Completed = false };
                await _ctx.TransferRequests.AddAsync(item);
                await _ctx.SaveChangesAsync();
                var data = _mapper.Map<TransferRequestResponse>(item);
                response = new Response<TransferRequestResponse>(data!) {
                    Succeeded = data != null
                };
            }
            
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    
    public async Task<PagedResponse<List<TransferRequestResponse>>> GetAllTransferAsync(TransferRequestFilter transferFilter) {
        var result = new PagedResponse<List<TransferRequestResponse>>();
        try {
            var query = _ctx.TransferRequests
            .Where(x => x.Completed == false)
            .Include(x => x.User);
            
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(transferFilter).ToListAsync();
            var response = _mapper.Map<List<TransferRequestResponse>>(data);
            var filter = new PaginationFilter {
                Page = transferFilter.Page,
                PerPage = transferFilter.PerPage
            };
            result = new PagedResponse<List<TransferRequestResponse>>(response, count, filter) {
                Succeeded = true
            };
        }
        catch (Exception e) {
            result.Errors = new[] {
                e.ToString()
            };
            _logger.LogError(e.ToString());
        }

        return result;
    }
    
    public async Task<Response<TransferRequestResponse?>> ApproveTransferAsync(TransferRequestResponse transfer) {
        var response = new Response<TransferRequestResponse?>();
        try {
            var item = await _ctx.TransferRequests.FindAsync(transfer.Id);
            if (item is null) return response;
            _mapper.Map(transfer, item);
            _ctx.Update(item);
            await _ctx.SaveChangesAsync();
            var data = _mapper.Map<TransferRequestResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }
        
        return response;
    }
    
    public async Task<Response<TransferRequestResponse?>> ArchiveTransferAsync(Guid id) {
        var response = new Response<TransferRequestResponse?>();
        try {
            var item = await _ctx.TransferRequests.FindAsync(id);
            if (item == null) return response;
            _ctx.Set<TransferRequestEntity>().Remove(item);
            await _ctx.SaveChangesAsync();
            var data = _mapper.Map<TransferRequestResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
}