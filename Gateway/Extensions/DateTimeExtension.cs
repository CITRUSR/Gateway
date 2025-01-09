namespace Gateway.Extensions;

public static class DateTimeExtension
{
    public static DateTime? ParseNullableDateTime(this string dateTimeString)
    {
        return string.IsNullOrEmpty(dateTimeString) ? null : DateTime.Parse(dateTimeString);
    }

    public static string? ToNullableString(this DateTime? dateTime)
    {
        return dateTime?.ToString();
    }
}
