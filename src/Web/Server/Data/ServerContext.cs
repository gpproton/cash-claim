using Microsoft.EntityFrameworkCore;
using XClaim.Common.Entities;

namespace XClaim.Web.Server.Data;

public class ServerContext : DbContext {
    public ServerContext(DbContextOptions<ServerContext> options) : base(options) { }

    public DbSet<UserEntity> Users { get; set; } = default!;
    public DbSet<TeamEntity> Teams { get; set; } = default!;
    public DbSet<BankEntity> Banks { get; set; } = default!;
    public DbSet<BankAccountEntity> BankAccounts { get; set; } = default!;
    public DbSet<CategoryEntity> Categories { get; set; } = default!;
    public DbSet<CommentEntity> Comments { get; set; } = default!;
    public DbSet<EventEntity> Events { get; set; } = default!;
    public DbSet<ClaimEntity> Claims { get; set; } = default!;
    public DbSet<FileEntity> Files { get; set; } = default!;
    public DbSet<PaymentEntity> Payments { get; set; } = default!;
}
