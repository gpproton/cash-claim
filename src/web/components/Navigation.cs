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
using Microsoft.AspNetCore.Components.Routing;

namespace XClaim.Web.Components;

public class Navigation : IDisposable {
    private const int MinHistorySize = 256;
    private const int AdditionalHistorySize = 64;
    private readonly NavigationManager _navigationManager;
    private readonly List<string> _history;

    public Navigation(NavigationManager navigationManager) {
        _navigationManager = navigationManager;
        _history = new List<string>(MinHistorySize + AdditionalHistorySize) {
            _navigationManager.Uri
        };
        _navigationManager.LocationChanged += OnLocationChanged!;
    }

    /// <summary>
    /// Navigates to the specified url.
    /// </summary>
    /// <param name="url">The destination url (relative or absolute).</param>
    public void NavigateTo(string url) {
        _navigationManager.NavigateTo(url);
    }

    /// <summary>
    /// Returns true if it is possible to navigate to the previous url.
    /// </summary>
    public bool CanNavigateBack => _history.Count >= 2;

    /// <summary>
    /// Navigates to the previous url if possible or does nothing if it is not.
    /// </summary>
    public void NavigateBack() {
        if (!CanNavigateBack) {
            return;
        }

        string? backPageUrl = _history[^2];
        _history.RemoveRange(_history.Count - 2, 2);
        _navigationManager.NavigateTo(backPageUrl);
    }

    private void OnLocationChanged(object sender, LocationChangedEventArgs e) {
        EnsureSize();
        _history.Add(e.Location);
    }

    private void EnsureSize() {
        if (_history.Count < MinHistorySize + AdditionalHistorySize) {
            return;
        }

        _history.RemoveRange(0, _history.Count - MinHistorySize);
    }

    public void Dispose() {
        _navigationManager.LocationChanged -= OnLocationChanged!;
    }
}