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
       CancellationToken cancellationToken = default
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
                    case EntityState.Added:
                        entry.Property("DeletedAt").IsModified = false;
                        trackable.CreatedAt = utcNow;
                        break;
                    case EntityState.Modified:
                        entry.Property("CreatedAt").IsModified = false;
                        entry.Property("DeletedAt").IsModified = false;
                        trackable.ModifiedAt = utcNow;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Property("CreatedAt").IsModified = false;
                        entry.Property("ModifiedAt").IsModified = false;
                        trackable.DeletedAt = utcNow;
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