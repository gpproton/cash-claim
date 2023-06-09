// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.ComponentModel.DataAnnotations;
using Axolotl.EFCore.Base;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Enums;

namespace XClaim.Common.Entity {
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Identifier), IsUnique = true)]
    public class UserEntity : AuditableEntity<Guid> {
        public string Identifier { get; set; } = string.Empty;
        [MaxLength(256)] public string Email { get; set; } = string.Empty;
        public string? ProfileImage { get; set; }
        [MaxLength(64)] public string Phone { get; set; } = string.Empty;
        [MaxLength(128)] public string FirstName { get; set; } = string.Empty;
        [MaxLength(128)] public string LastName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public UserPermission Permission { get; set; } = UserPermission.Standard;
        public CompanyEntity? Company { get; set; }
        [Display(AutoGenerateField = false)] public int? CompanyId { get; set; }
        public CompanyEntity? CompanyManaged { get; set; }
        [Display(AutoGenerateField = false)] public Guid? CompanyManagedId { get; set; }
        public TeamEntity? Team { get; set; }
        [Display(AutoGenerateField = false)] public Guid? TeamId { get; set; }
        public TeamEntity? TeamManaged { get; set; }
        [Display(AutoGenerateField = false)] public Guid? TeamManagedId { get; set; }
        public BankAccountEntity? BankAccount { get; set; }
        public NotificationEntity? Notification { get; set; }
        public SettingsEntity? Setting { get; set; }
        public CurrencyEntity? Currency { get; set; }
        [Display(AutoGenerateField = false)] public int? CurrencyId { get; set; }
        public bool Active { get; set; }
        [MaxLength(128)] public string? Token { get; set; }
        public string? Image { get; set; }
    }
}