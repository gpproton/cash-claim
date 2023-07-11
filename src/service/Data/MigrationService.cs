// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.EntityFrameworkCore;
using XClaim.Common.Context;

namespace XClaim.Service.Data;

public class MigrationService(ILogger<MigrationService> logger, IServiceScopeFactory factory) : BackgroundService {

    protected override async Task ExecuteAsync(CancellationToken cancellationToken) {
        logger.LogInformation("Starting migration...");
        IServiceProvider? sp = factory.CreateScope().ServiceProvider;

        await using ServiceContext? context = sp.GetService<ServiceContext>();
        if (context is null) {
            return;
        }

        if (context.Database.IsRelational()) {
            await context.Database.MigrateAsync(cancellationToken);
        }

        using (Task<bool>? any = context.Server.AnyAsync(cancellationToken)) {
            if (!await any) {
                logger.LogInformation("Starting seeding...");

                // await context.Posts.AddRangeAsync(posts, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                logger.LogInformation("Completed seeding...");
            }
        }

        logger.LogInformation("Completed migration...");
    }
}