using Microsoft.EntityFrameworkCore;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Data;

public partial class ServerContext {
    // REF: https://threewill.com/how-to-auto-generate-created-updated-field-in-ef-core/
    public override int SaveChanges(bool acceptAllChangesOnSuccess) {
        OnBeforeSaving();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override async Task<int> SaveChangesAsync(
       bool acceptAllChangesOnSuccess,
       CancellationToken cancellationToken = default(CancellationToken)
    ) {
        OnBeforeSaving();
        return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                      cancellationToken));
    }

    private void OnBeforeSaving() {
        var entries = ChangeTracker.Entries();
        var utcNow = DateTime.UtcNow;

        foreach (var entry in entries) {
            if (entry.Entity is BaseEntity trackable) {
                switch (entry.State) {
                    case EntityState.Modified:
                        trackable.ModifiedAt = utcNow;
                        entry.Property("CreatedAt").IsModified = false;
                        entry.Property("DeletedAt").IsModified = false;
                        break;
                    case EntityState.Added:
                        trackable.CreatedAt = utcNow;
                        break;
                    case EntityState.Deleted:
                        entry.Property("CreatedAt").IsModified = false;
                        entry.Property("ModifiedAt").IsModified = false;
                        entry.Property("DeletedAt").CurrentValue = utcNow;
                        entry.State = EntityState.Modified;
                        break;
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                    default:
                        break;
                }
            }
        }
    }
}