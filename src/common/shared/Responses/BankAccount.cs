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

public class BankAccount : AuditableResponse<Guid> {
    public string FullName { get; set; } = string.Empty;
    public Bank? Bank { get; set; }
    public Guid? BankId { get; set; }
    public User? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public string? Number { get; set; }
    public string? Description { get; set; }
}