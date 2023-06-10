// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Text;
using System.Text.Json;
using Blazored.SessionStorage;

namespace XClaim.Web.Shared;

public static class SessionStorageExtension {
    public static async Task SaveAsync<T>(this ISessionStorageService sessionStorageService, string key, T item) {
        string? itemJson = JsonSerializer.Serialize(item);
        byte[]? itemJsonBytes = Encoding.UTF8.GetBytes(itemJson);
        string? base64Json = Convert.ToBase64String(itemJsonBytes);
        await sessionStorageService.SetItemAsync(key, base64Json);
    }

    public static async Task<T?> GetAsync<T>(this ISessionStorageService sessionStorageService, string key) {
        string? base64Json = await sessionStorageService.GetItemAsync<string>(key);
        if (base64Json is null) {
            return default!;
        }

        byte[]? itemJsonBytes = Convert.FromBase64String(base64Json);
        string? itemJson = Encoding.UTF8.GetString(itemJsonBytes);
        T? item = JsonSerializer.Deserialize<T>(itemJson);

        return item;
    }
}