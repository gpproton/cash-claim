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

namespace XClaim.Common.Entity {
    public class CompanyEntity : BaseEntity<int> {
        public bool Active { get; set; }
        [MaxLength(64)] public string ShortName { get; set; } = String.Empty;
        [MaxLength(128)] public string FullName { get; set; } = String.Empty;
        [Required] [MaxLength(256)] public string AdminEmail { get; set; } = String.Empty;
        public UserEntity? Manager { get; set; }
        [Display(AutoGenerateField = false)] public Guid? ManagerId { get; set; }
        public ICollection<UserEntity>? Members { get; set; }
    }
}