// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Net.Http.Headers;
using Axolotl.Http;
using XClaim.Common.Responses;
using XClaim.Web.Shared.States;

namespace XClaim.Web.Shared;

public class HttpService : AbstractHttpService {
    private readonly Lazy<AuthState> _state;

    public HttpService(HttpClient http, Lazy<AuthState> state) : base(http) {
        _state = state;
    }

    protected override async Task AddJwtHeader(HttpRequestMessage request) {
        AuthResponse? user = await _state.Value.GetSession();
        bool isApiUrl = !request!.RequestUri!.IsAbsoluteUri;
        if (user != null && isApiUrl) {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
        }
    }

    protected override async Task SignOut() {
        await _state.Value.TriggerSignOut();
    }
}