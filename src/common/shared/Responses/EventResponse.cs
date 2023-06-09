// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Axolotl.Response;
using XClaim.Common.Enums;

namespace XClaim.Common.Responses {
    public class EventResponse : BaseResponse<Guid> {
        public DateTime CreatedAt { get; set; }
        public EventType Type { get; set; } = EventType.Claim;
        public ClaimResponse? Claim { get; set; }
        public Guid? ClaimId { get; set; }
        public Payment? Payment { get; set; }
        public Guid? PaymentId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}