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

public class CommentEntity : BaseEntity<Guid> {
    public ProfileEntity? User { get; set; }
    public Guid? UserId { get; set; }
    public ClaimEntity? Claim { get; set; }
    [Display(AutoGenerateField = false)] public Guid? ClaimId { get; set; }
    public PaymentEntity? Payment { get; set; }
    [Display(AutoGenerateField = false)] public Guid? PaymentId { get; set; }
    [MaxLength(1024)] public string? Content { get; set; }
}