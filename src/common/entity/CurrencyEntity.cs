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

namespace XClaim.Common.Entity;

[Index(nameof(Name), IsUnique = true)]
[Index(nameof(Code), IsUnique = true)]
public sealed class CurrencyEntity : BaseEntity<int> {
    public string Name { get; set; } = string.Empty;
    public string? Symbol { get; set; } = string.Empty;
    [MaxLength(3)]
    public string Code { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
}