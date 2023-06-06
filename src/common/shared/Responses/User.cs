// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Axolotl.Response;
using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Responses {
    public sealed class User : AuditableResponse<Guid> {
        public string Identifier { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ProfileImage { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public UserPermission Permission { get; set; } = UserPermission.Standard;
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
        public Company? CompanyManaged { get; set; }
        public Guid? CompanyManagedId { get; set; }
        public Team? Team { get; set; }
        public Guid? TeamId { get; set; }
        public Team? TeamManaged { get; set; }
        public Guid? TeamManagedId { get; set; }
        public BankAccount? BankAccount { get; set; }
        public Notification? Notification { get; set; }
        public Settings? Setting { get; set; }
        public Currency? Currency { get; set; }
        public int? CurrencyId { get; set; }
        public bool Active { get; set; }
        public string? Token { get; set; }
        public string? Image { get; set; }
    }
}