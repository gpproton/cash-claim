﻿namespace CashClaim.Common.Extensions;

public static class DateTimeExtensions {
    public static TimeOnly ToTimeOnly(this DateTime dateTime) {
        return TimeOnly.FromDateTime(dateTime);
    }

    public static DateOnly ToDateOnly(this DateTime dateTime) {
        return DateOnly.FromDateTime(dateTime);
    }

    public static string TimeAgo(this DateTime dateTime) {
        var result = string.Empty;
        var timeSpan = DateTime.Now.Subtract(dateTime);

        if (timeSpan <= TimeSpan.FromSeconds(60))
            result = string.Format("{0} seconds ago", timeSpan.Seconds);
        else if (timeSpan <= TimeSpan.FromMinutes(60))
            result = timeSpan.Minutes > 1 ? string.Format("{0} minutes ago", timeSpan.Minutes) : "a minute ago";
        else if (timeSpan <= TimeSpan.FromHours(24))
            result = timeSpan.Hours > 1 ? string.Format("{0} hours ago", timeSpan.Hours) : "an hour ago";
        else if (timeSpan <= TimeSpan.FromDays(30))
            result = timeSpan.Days > 1 ? string.Format("{0} days ago", timeSpan.Days) : "yesterday";
        else if (timeSpan <= TimeSpan.FromDays(365))
            result = timeSpan.Days > 30 ? string.Format("{0} months ago", timeSpan.Days / 30) : "a month ago";
        else
            result = timeSpan.Days > 365 ? string.Format("{0} years ago", timeSpan.Days / 365) : "a year ago";

        return result;
    }
}