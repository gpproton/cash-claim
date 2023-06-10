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

namespace XClaim.Web.Shared.States;

public class ThemeState : RootState {
    public bool IsLightMode { get; private set; } = true;

    public MudTheme CurrentTheme { get; private set; } = new();

    public void ToggleTheme() {
        IsLightMode = !IsLightMode;
        CurrentTheme = IsLightMode ? new MudTheme() : GenerateDarkTheme();
        NotifyStateChanged();
    }

    public void SetLightMode(bool value) {
        IsLightMode = value;
        CurrentTheme = IsLightMode ? new MudTheme() : GenerateDarkTheme();
        NotifyStateChanged();
    }

    private static MudTheme GenerateDarkTheme() {
        return new MudTheme {
            Palette = new PaletteDark {
                Black = "#27272f",
                Background = "#32333d",
                BackgroundGrey = "#27272f",
                Surface = "#373740",
                TextPrimary = "#ffffffb3",
                TextSecondary = "rgba(255,255,255, 0.50)",
                AppbarBackground = "#27272f",
                AppbarText = "#ffffffb3",
                DrawerBackground = "#27272f",
                DrawerText = "#ffffffb3",
                DrawerIcon = "#ffffffb3"
            }
        };
    }
}