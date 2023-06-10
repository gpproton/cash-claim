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

public class MigrationService : BackgroundService {
    private readonly ILogger<MigrationService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public MigrationService(ILogger<MigrationService> logger, IServiceScopeFactory factory) {
        _logger = logger;
        _scopeFactory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken) {
        _logger.LogInformation("Starting migration...");
        IServiceProvider? sp = _scopeFactory.CreateScope().ServiceProvider;

        await using ServiceContext? context = sp.GetService<ServiceContext>();
        if (context is null) {
            return;
        }

        if (context.Database.IsRelational()) {
            await context.Database.MigrateAsync(cancellationToken);
        }

        using (Task<bool>? any = context.Server.AnyAsync(cancellationToken)) {
            if (!await any) {
                _logger.LogInformation("Starting seeding...");

                // await context.Posts.AddRangeAsync(posts, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Completed seeding...");
            }
        }

        _logger.LogInformation("Completed migration...");
    }
}