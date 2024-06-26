using System.Web;

namespace CashClaim.Common.Extensions;

public static class ObjectExtensions {
    public static string GetQueryString(this object? obj) {
        if (obj == null) return string.Empty;
        var properties = from p in obj.GetType().GetProperties()
                         where p.GetValue(obj, null) != null
                         select p.Name + "=" + HttpUtility.UrlEncode(p!.GetValue(obj, null).ToString());

        return "?" + String.Join("&", properties.ToArray());
    }
}