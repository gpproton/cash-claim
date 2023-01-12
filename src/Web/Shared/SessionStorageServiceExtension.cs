using System.Text;
using System.Text.Json;
using Blazored.SessionStorage;

namespace XClaim.Web.Shared;

public static class SessionStorageServiceExtension {
    public static async Task SaveAsync<T>(this ISessionStorageService sessionStorageService, string key, T item) {
        var itemJson = JsonSerializer.Serialize(item);
        var itemJsonBytes = Encoding.UTF8.GetBytes(itemJson);
        var base64Json = Convert.ToBase64String(itemJsonBytes);
        await sessionStorageService.SetItemAsync(key, base64Json);
    }

    public static async Task<T?> GetAsync<T>(this ISessionStorageService sessionStorageService, string key) {
        var base64Json = await sessionStorageService.GetItemAsync<string>(key);
        var itemJsonBytes = Convert.FromBase64String(base64Json);
        var itemJson = Encoding.UTF8.GetString(itemJsonBytes);
        var item = JsonSerializer.Deserialize<T>(itemJson);

        return item;
    }
}