// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using MudBlazor;

namespace XClaim.Web.Shared;

public static class WebConst {
    public const string RootApi = "/api/v1";
    public const string RootUri = "https://localhost:7001";
    public const string ApiAuth = "auth/sign-in";
    public const string AppHome = "app/overview";
    public const string AppAuth = "app/auth";
    public const string AppRegister = "app/registration";
    public const string SessionKey = "UserSession";
    public static readonly DateRange AppDateRange = new(DateTime.Now.AddDays(-7), DateTime.Now);
    public static readonly int[] AppPaged = { 100, 250, 2000 };
    public const string TableHeight = "calc(100vh - 224px)";
}