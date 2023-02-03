using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nextended.Core.Extensions;
using XClaim.Common.Dtos;
using XClaim.Common.Enums;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Helpers;
using XClaim.Web.Server.Modules.UserModule;

namespace XClaim.Web.Server.Modules.ProfileModule;

public class ProfileService : IProfileService {
    
    private readonly ServerContext _ctx;
    private readonly IMapper _mapper;
    private readonly ILogger<ProfileService> _logger;
    private readonly IdentityHelper _identity;
    private readonly UserService _user;
    
    public ProfileService(ServerContext ctx, IMapper mapper, ILogger<ProfileService> logger, IdentityHelper identity, UserService user) {
        _ctx = ctx;
        _mapper = mapper;
        _logger = logger;
        _identity = identity;
        _user = user;
    }

    private async Task<Guid?> GetId() {
        var profile = await _identity.GetUser();
        return profile!.Id;
    }
    
    public async Task<Response<AuthResponse?>> GetAccountAsync() {
        var response = new Response<AuthResponse?>();
        var profile = await _identity.GetAuthProfile();
        if (!_identity.IsAuthenticated) return response;
        var account = (await _user.GetByIdentifierAsync(profile!.Data!.Identifier)).Data;
        if (account != null) {
            profile.Data = account;
            profile.Confirmed = true;
        }
        var role = account?.Permission != null ? Enum.GetName(account.Permission)! : Enum.GetName(UserPermission.Anonymous)!;
        profile.Role = role;

        return new Response<AuthResponse?>(profile) {
            Succeeded = profile.ExpiresIn > 0
        };
    }
    
    private async Task<BankAccountEntity?> GetBankAccount() {
        var id = await this.GetId();
        return await _ctx.UserBankAccount.Where(x => x.OwnerId == id)
               .Include(x => x.Bank).FirstOrDefaultAsync();
    }

    public async Task<Response<BankAccountResponse?>> GetBankAccountAsync() {
        var response = new Response<BankAccountResponse?>();
        try {
            var data = _mapper.Map<BankAccountResponse>(await this.GetBankAccount());
            response.Data = data;
            response.Succeeded = data != null;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    public async Task<Response<BankAccountResponse?>> UpdateBankAccountAsync(BankAccountResponse account) {
        var response = new Response<BankAccountResponse?>();
        var id = await this.GetId();
        if (id == null ) return response;

        try {
            var userBankAccount = await this.GetBankAccount();
            var item = _mapper.Map<BankAccountEntity>(account);
            if (userBankAccount == null) {
                item.OwnerId = id;
                await _ctx.UserBankAccount.AddAsync(item);
                await _ctx.SaveChangesAsync();
            } else {
                _ctx.UserBankAccount.Update(item);
                await _ctx.SaveChangesAsync();
            }
            var data = _mapper.Map<BankAccountResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    private async Task<SettingEntity?> GetSetting() {
        var id = await this.GetId();
        return await _ctx.UserSetting.Where(x => x.OwnerId == id)
               .Include(x => x.Owner)
               .AsNoTracking()
               .FirstOrDefaultAsync();
    }
    
    public async Task<Response<SettingResponse?>> GetSettingAsync() {
        var response = new Response<SettingResponse?>();
        try {
            var data = _mapper.Map<SettingResponse>(await this.GetSetting());
            response.Data = data;
            response.Succeeded = true;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    public async Task<Response<SettingResponse?>> UpdateSettingAsync(SettingResponse setting) {
        var response = new Response<SettingResponse?>();
        var id = await this.GetId();
        
        try {
            var userSetting = await this.GetSetting();
            var item = setting.MapTo<SettingEntity>();
            if (userSetting == null) {
                item.OwnerId = id;
                await _ctx.UserSetting.AddAsync(item);
                await _ctx.SaveChangesAsync();
            } else {
                _mapper.Map(userSetting, item);
                _ctx.UserSetting.Update(item);
                await _ctx.SaveChangesAsync();
            }
            var data = _mapper.Map<SettingResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    private async Task<NotificationEntity?> GetNotification() {
        var id = await this.GetId();

        return await _ctx.UserNotification.Where(x => x.OwnerId == id)
               .Include(x => x.Owner)
               .AsNoTracking()
               .FirstOrDefaultAsync();
    }
    
    public async Task<Response<NotificationResponse?>> GetNotificationAsync() {
        var response = new Response<NotificationResponse?>();
        try {
            var data = _mapper.Map<NotificationResponse>(await this.GetNotification());
            response.Data = data;
            response.Succeeded = true;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    public async Task<Response<NotificationResponse?>> UpdateNotificationAsync(NotificationResponse notification) {
        var response = new Response<NotificationResponse?>();

        try {
            var userNotification = await this.GetNotification();
            var id = await this.GetId();
            var item = _mapper.Map<NotificationEntity>(notification);
            if (userNotification == null) {
                item.OwnerId = id;
                await _ctx.UserNotification.AddAsync(item);
                await _ctx.SaveChangesAsync();
            } else {
                _mapper.Map(userNotification, item);
                _ctx.UserNotification.Update(item);
                await _ctx.SaveChangesAsync();
            }
            var data = _mapper.Map<NotificationResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
}