// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Axolotl.EFCore.Base;
using Axolotl.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Entity;
using XClaim.Common.Enums;

namespace XClaim.Service.Data;

public class ServiceContext : AbstractDbContext {
    private static DbContextOptions<TContext> ChangeOptionsType<TContext>(DbContextOptions options) where TContext : DbContext
        => (DbContextOptions<TContext>)options;
    public ServiceContext(DbContextOptions<ServiceContext> options) : base(ChangeOptionsType<ServiceContext>(options)) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite") modelBuilder.DateTimeOffsetToBinary();

        var entitiesAssembly = typeof (ServiceContext).Assembly;
        modelBuilder.RegisterAllEntities<BaseEntity<Guid>>(entitiesAssembly);
        modelBuilder.RegisterAllEntities<AuditableEntity<Guid>>(entitiesAssembly);
        modelBuilder.RegisterSoftDeleteFilter();
        modelBuilder.EnableAutoHistory<AuditEntity>(o => { });
        modelBuilder.RegisterEnumConverters<NotificationChannels>(typeof(ICollection<NotificationChannels>));
        modelBuilder.RegisterEnumConverters<EventType>(typeof(ICollection<EventType>));
    }

    public DbSet<ServerEntity> Server { get; set; } = default!;
    public DbSet<UserEntity> Users { get; set; } = default!;
    public DbSet<NotificationEntity> UserNotifications { get; set; } = default!;
    public DbSet<SettingsEntity> UserSetting { get; set; } = default!;
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
    public DbSet<AuditEntity> AuditHistories { get; set; } = default!;
}