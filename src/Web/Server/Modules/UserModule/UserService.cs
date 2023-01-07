using Microsoft.EntityFrameworkCore;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.UserModule;

public class UserService : IUserRepository {
    private readonly ServerContext _ctx;
    public UserService(ServerContext ctx) {
        _ctx = ctx;
    }
    
    public async Task<List<UserEntity>> GetAll() {
        return await _ctx.Users.ToListAsync();
    }

    public async Task Create(UserEntity user) {
        await _ctx.Users.AddAsync(user);
        await _ctx.SaveChangesAsync();
    }

    public async Task<UserEntity?> Modify(Guid id, UserEntity user) {
        var item = await _ctx.Users.FindAsync(id);
        if (item is null) return null;
        _ctx.Update(user);
        await _ctx.SaveChangesAsync();
        return user;
    }

    public async Task<UserEntity?> GetById(Guid id) {
        return await _ctx.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<UserEntity?> Delete(Guid id) {
        var item = await _ctx.Users.FindAsync(id);
        if (item == null) return null;

        _ctx.Users.Remove(item);
        await _ctx.SaveChangesAsync();
        
        return item;
    }
}