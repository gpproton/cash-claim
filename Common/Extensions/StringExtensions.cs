namespace XClaim.Common.Extensions;

public static class StringExtensions {
    public static string Truncate(this string? value, int length = 15) {
        if (value == null) return string.Empty;
        return value.Length <= length ? value : value[..length] + "...";
    }
}