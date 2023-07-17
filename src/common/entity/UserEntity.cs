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

namespace XClaim.Common.Entity;

public class UserEntity : AuditableEntity<Guid> {
    public AccountEntity? Account { get; set; }
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