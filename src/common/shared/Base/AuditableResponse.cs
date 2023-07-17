// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Text.Json.Serialization;

namespace XClaim.Common.Base; 

public abstract class AuditableResponse : BaseResponse {
    public DateTime? CreatedAt { get; set; }
    [JsonIgnore] public DateTime? UpdatedAt { get; set; }
    [JsonIgnore] public DateTime? DeletedAt { get; set; }
}

public abstract class AuditableResponse<TKey> : BaseResponse<TKey> where TKey : notnull {
    public DateTime? CreatedAt { get; set; }
    [JsonIgnore] public DateTime? UpdatedAt { get; set; }
    [JsonIgnore] public DateTime? DeletedAt { get; set; }
}