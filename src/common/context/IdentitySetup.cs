// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using XClaim.Common.Entity;

namespace XClaim.Common.Context;

public static class IdentitySetup {
    public static IServiceCollection RegisterEntityIdentity(this IServiceCollection services) {
        services.AddIdentityCore<AccountEntity>()
            .AddEntityFrameworkStores<ServiceContext>()
            .AddApiEndpoints();

        return services;
    }
}