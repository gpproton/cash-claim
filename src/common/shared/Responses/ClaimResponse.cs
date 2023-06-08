// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Responses;

public class ClaimResponse : AuditableResponse<Guid> {
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public decimal Amount { get; set; }
    public Currency? Currency { get; set; }
    public int? CurrencyId { get; set; }
    public Payment? Payment { get; set; }
    public Guid? PaymentId { get; set; }
    public Category? Category { get; set; }
    public Guid? CategoryId { get; set; }
    public Company? Company { get; set; }
    public int? CompanyId { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public User? User { get; set; }
    public Guid? UserId { get; set; }
    public DateTime? CancelledAt { get; set; }
    public User? ReviewedBy { get; set; }
    public Guid? ReviewedById { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public User? ConfirmedBy { get; set; }
    public Guid? ConfirmedById { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public User? ApprovedBy { get; set; }
    public Guid? ApprovedById { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public Guid? RejectedById { get; set; }
    public DateTime? RejectedAt { get; set; }
    public ICollection<FileResponse>? Files { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}