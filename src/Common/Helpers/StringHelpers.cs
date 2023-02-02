using System;

namespace XClaim.Common.Helpers;

public static class StringHelpers {
    public static string GetInitialsText(string?[] value) {
        if (value.Length < 2) return "FL";
        var f = value[0]?.ToUpper();
        var l = value[^1]?.ToUpper();
        if (f == null || l == null) return "FL";
        try {
            return string.Concat(f[0], l[0]);
        } catch (Exception e) {
            // ignore
        }
        return string.Empty;
    }
}