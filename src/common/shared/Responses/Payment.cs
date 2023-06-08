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

namespace XClaim.Common.Responses;

public class Payment : AuditableResponse<Guid> {
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public decimal Amount { get; set; }
    public User? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public Company? Company { get; set; }
    public int? CompanyId { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public bool Confirmed => ConfirmedAt != null;
    public int Count { get; set; }
    public ICollection<ClaimResponse>? Claims { get; set; }
    public ICollection<FileResponse>? Files { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}