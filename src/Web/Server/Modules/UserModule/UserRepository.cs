using Microsoft.EntityFrameworkCore;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.UserModule;


public class UserRepository : IUserRepository {
    private readonly ServerContext _db;
    public UserRepository(ServerContext db) {
        _db = db;
    }

    public async Task Create(UserEntity user) {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task<bool> Delete(Guid id) {
        var student = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (student == null) return false;

        _db.Users.Remove(student);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<List<UserEntity>> GetAll() {
        return await _db.Users.ToListAsync();
    }

    public async Task<UserEntity?> GetById(Guid id) {
        return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}