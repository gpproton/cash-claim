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

namespace XClaim.Common.Responses {
    public class Settings : AuditableResponse<Guid> {
        public User? User { get; set; }
        public Guid? UserId { get; set; }
        public bool DarkMode { get; set; }
        public AppLanguage Language { get; set; } = AppLanguage.English;
    }
}