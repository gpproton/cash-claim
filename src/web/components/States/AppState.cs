// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.AspNetCore.Components;
using XClaim.Common;
using XClaim.Common.Responses;

namespace XClaim.Web.Components.States;

public class AppState : RootState {
    public RenderFragment? LayoutTitle { get; private set; }

    public string? AppTitle { get; private set; } = SharedConst.ServiceName;

    public Server? ServerState { get; private set; }

    public bool IsSidebarOpen { get; private set; } = true;

    public void SetLayoutTitle(RenderFragment? value) {
        LayoutTitle = value;
        NotifyStateChanged();
    }

    public void SetAppTitle(string? value) {
        AppTitle = value;
        NotifyStateChanged();
    }

    public void ToggleSidebar() {
        IsSidebarOpen = !IsSidebarOpen;
        NotifyStateChanged();
    }

    public void LoadServerState(Server server) {
        ServerState = server;
        AppTitle = server.ServiceName;
        NotifyStateChanged();
    }
}