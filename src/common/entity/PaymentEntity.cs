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

public class PaymentEntity : AuditableEntity<Guid> {
    [MaxLength(256)] public string? Description { get; set; }
    [MaxLength(1024)] public string? Notes { get; set; }
    public decimal Amount { get; set; }
    public UserEntity? User { get; set; }
    public Guid? UserId { get; set; }
    public CompanyEntity? Company { get; set; }
    [Display(AutoGenerateField = false)] public int? CompanyId { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public bool Confirmed => ConfirmedAt != null;
    public int Count { get; set; }
    public ICollection<ClaimEntity>? Claims { get; set; }
    public ICollection<FileEntity>? Files { get; set; }
    public ICollection<CommentEntity>? Comments { get; set; }
}