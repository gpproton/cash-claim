using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Helpers;

namespace XClaim.Web.Server.Modules.ProfileModule;

public class ProfileService : IProfileService {
    
    private readonly ServerContext _ctx;
    private readonly IMapper _mapper;
    private readonly ILogger<ProfileService> _logger;
    private readonly IdentityHelper _identity;
    
    public ProfileService(ServerContext ctx, IMapper mapper, ILogger<ProfileService> logger, IdentityHelper identity) {
        _ctx = ctx;
        _mapper = mapper;
        _logger = logger;
        _identity = identity;
    }

    private async Task<Guid?> GetId() {
        var profile = await _identity.GetUser();
        return profile!.Id;
    }

    private async Task<BankAccountEntity?> GetBankAccount() {
        var id = await this.GetId();
        return await _ctx.UserBankAccount.FirstOrDefaultAsync(x => x.OwnerId == id);
    }

    public async Task<Response<BankAccountResponse?>> GetBankAccountAsync() {
        var response = new Response<BankAccountResponse?>();
        var id = await this.GetId();
        if (id == null ) return response;
        try {
            var data = _mapper.Map<BankAccountResponse>(await this.GetBankAccount());
            response.Data = data;
            response.Succeeded = true;
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
            BankAccountEntity item;
            if (userBankAccount == null) {
                item = _mapper.Map<BankAccountEntity>(account);
                item.OwnerId = id;
                await _ctx.UserBankAccount.AddAsync(item);
                await _ctx.SaveChangesAsync();
            } else {
                item = _mapper.Map<BankAccountEntity>(account);
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
        return await _ctx.UserSetting.FirstOrDefaultAsync(x => x.OwnerId == id);
    }
    
    public async Task<Response<SettingResponse?>> GetSettingAsync() {
        var response = new Response<SettingResponse?>();
        var id = await this.GetId();
        if (id == null ) return response;
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
        if (id == null ) return response;
        
        try {
            var userSetting = await this.GetSetting();
            SettingEntity item;
            if (userSetting == null) {
                item = _mapper.Map<SettingEntity>(setting);
                item.OwnerId = id;
                await _ctx.UserSetting.AddAsync(item);
                await _ctx.SaveChangesAsync();
            } else {
                item = _mapper.Map<SettingEntity>(setting);
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

        return await _ctx.UserNotification.FirstOrDefaultAsync(x => x.OwnerId == id);
    }
    
    public async Task<Response<NotificationResponse?>> GetNotificationAsync() {
        var response = new Response<NotificationResponse?>();
        var id = await this.GetId();
        if (id == null ) return response;
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
        var id = await this.GetId();
        if (id == null ) return response;

        try {
            var userNotification = await this.GetNotification();
            NotificationEntity item;
            if (userNotification == null) {
                item = _mapper.Map<NotificationEntity>(notification);
                item.OwnerId = id;
                await _ctx.UserNotification.AddAsync(item);
                await _ctx.SaveChangesAsync();
            } else {
                item = _mapper.Map<NotificationEntity>(notification);
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