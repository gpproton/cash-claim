using System.Collections.Specialized;
using System.Web;

namespace XClaim.Common.Extensions;

public static class NameValueExtensions {
    public static string ToQueryString(this NameValueCollection? source, bool removeEmptyEntries = false) {
        if (source == null) return string.Empty;

        return "?" + String.Join("&", source.AllKeys
        .Where(key => !removeEmptyEntries || source.GetValues(key)!.Any(value => !String.IsNullOrEmpty(value)))
        .SelectMany(key => source.GetValues(key)!
        .Where(value => !removeEmptyEntries || !String.IsNullOrEmpty(value))
        .Select(value => $"{HttpUtility.UrlEncode(key)}={(HttpUtility.UrlEncode(value))}"))
        .ToArray());
    }
}