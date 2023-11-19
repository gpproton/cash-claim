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

public class BankAccountEntity : AuditableEntity<Guid> {
    public string FullName { get; set; } = string.Empty;
    public BankEntity? Bank { get; set; }
    [Display(AutoGenerateField = false)] public Guid? BankId { get; set; }
    public ProfileEntity? User { get; set; }
    [Display(AutoGenerateField = false)] public Guid? UserId { get; set; }
    [Required] [MaxLength(20)] public string? Number { get; set; }
    [MaxLength(1024)] public string? Description { get; set; }
}