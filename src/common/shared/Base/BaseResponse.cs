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

namespace XClaim.Common.Base;

public abstract class BaseResponse : IResponse {
}

public abstract class BaseResponse<TKey> : IResponse where TKey : notnull {
    public TKey? Id { get; set; }
}