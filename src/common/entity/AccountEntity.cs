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
using Axolotl.EFCore.Interfaces;
using Axolotl.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Enums;

namespace XClaim.Common.Entity;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Identifier), IsUnique = true)]
public sealed class AccountEntity : IdentityUser, IAuditableEntity<Guid>, IAggregateRoot, IResponse {
    public string Identifier { get; set; } = string.Empty;
    public string? ProfileImage { get; set; }
    [MaxLength(128)] public string FirstName { get; set; } = string.Empty;
    [MaxLength(128)] public string LastName { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public UserPermission Permission { get; set; } = UserPermission.Standard;
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public Guid DeletedBy { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}