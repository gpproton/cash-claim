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

namespace XClaim.Common.Entity;

public class ServerEntity : BaseEntity<Guid> {
    public string ServiceName { get; set; } = string.Empty;
    public string AdminEmail { get; set; } = string.Empty;
    public bool MaintenanceMode { get; set; }
    public string MaintenanceText { get; set; } = string.Empty;
    public CurrencyEntity? Currency { get; set; }
    public Guid? CurrencyId { get; set; }
}