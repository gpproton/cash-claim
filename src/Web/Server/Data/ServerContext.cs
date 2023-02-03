using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using XClaim.Common.Base;
using XClaim.Common.Enums;
using XClaim.Web.Server.Converters;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Data;

public partial class ServerContext : DbContext {
    public ServerContext(DbContextOptions<ServerContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder mx) {
        // base.OnModelCreating(mx);

        // Handle soft delete query filter
        foreach (var entityType in mx.Model.GetEntityTypes())
            if (typeof(IBaseEntity).IsAssignableFrom(entityType.ClrType))
                entityType.AddSoftDeleteQueryFilter();

        // User - Company (Manager) One to One
        mx.Entity<CompanyEntity>()
            .HasOne(c => c.Manager)
            .WithOne(u => u.CompanyManaged)
            .HasForeignKey<CompanyEntity>(c => c.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);

        // User - Team (Manager) One to One
        mx.Entity<TeamEntity>()
            .HasOne(t => t.Manager)
            .WithOne(u => u.TeamManaged)
            .HasForeignKey<TeamEntity>(t => t.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);
        
        mx.Entity<NotificationEntity>()
        .Property(e => e.Channels)
        .HasConversion(new EnumCollectionJsonValueConverter<NotificationChannels>())
        .Metadata.SetValueComparer(new CollectionValueComparer<NotificationChannels>());
        
        mx.Entity<NotificationEntity>()
        .Property(e => e.Types)
        .HasConversion(new EnumCollectionJsonValueConverter<EventType>())
        .Metadata.SetValueComparer(new CollectionValueComparer<EventType>());

        // Initialize database seeding
        new DbInitializer(mx).Seed();
    }

    public DbSet<ServerEntity> Server { get; set; } = default!;
    public DbSet<UserEntity> Users { get; set; } = default!;
    public DbSet<NotificationEntity> UserNotification { get; set; } = default!;
    public DbSet<SettingEntity> UserSetting { get; set; } = default!;
    public DbSet<BankAccountEntity> UserBankAccount { get; set; } = default!;
    public DbSet<TeamEntity> Teams { get; set; } = default!;
    public DbSet<BankEntity> Banks { get; set; } = default!;
    public DbSet<CompanyEntity> Companies { get; set; } = default!;
    public DbSet<CategoryEntity> Categories { get; set; } = default!;
    public DbSet<CommentEntity> Comments { get; set; } = default!;
    public DbSet<EventEntity> Events { get; set; } = default!;
    public DbSet<ClaimEntity> Claims { get; set; } = default!;
    public DbSet<FileEntity> Files { get; set; } = default!;
    public DbSet<PaymentEntity> Payments { get; set; } = default!;
    public DbSet<TransferRequestEntity> TransferRequests { get; set; } = default!;
}