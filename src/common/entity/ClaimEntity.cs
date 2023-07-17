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
using XClaim.Common.Enums;

namespace XClaim.Common.Entity; 

public class ClaimEntity : AuditableEntity<Guid> {
    [Required] [MaxLength(256)] public string? Description { get; set; }
    [MaxLength(1024)] public string? Notes { get; set; }
    public decimal Amount { get; set; }
    public CurrencyEntity? Currency { get; set; }
    [Display(AutoGenerateField = false)] public int? CurrencyId { get; set; }
    public PaymentEntity? Payment { get; set; }
    [Display(AutoGenerateField = false)] public Guid? PaymentId { get; set; }
    [Required] public CategoryEntity? Category { get; set; }
    [Display(AutoGenerateField = false)] public Guid? CategoryId { get; set; }
    public CompanyEntity? Company { get; set; }
    [Display(AutoGenerateField = false)] public int? CompanyId { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public UserEntity? User { get; set; }
    public Guid? UserId { get; set; }
    public DateTime? CancelledAt { get; set; }
    public UserEntity? ReviewedBy { get; set; }
    [Display(AutoGenerateField = false)] public Guid? ReviewedById { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public UserEntity? ConfirmedBy { get; set; }
    [Display(AutoGenerateField = false)] public Guid? ConfirmedById { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public UserEntity? ApprovedBy { get; set; }
    [Display(AutoGenerateField = false)] public Guid? ApprovedById { get; set; }
    public DateTime? ApprovedAt { get; set; }
    [Display(AutoGenerateField = false)] public Guid? RejectedById { get; set; }
    public DateTime? RejectedAt { get; set; }
    public ICollection<FileEntity>? Files { get; set; }
    public ICollection<CommentEntity>? Comments { get; set; }
}