using System.Globalization;

namespace SmartBodyDomain.Tests.Steps;

public static class DateOnlyExtensions
{
    private static readonly CultureInfo _german = new CultureInfo("de-DE");

    public static DateOnly ToDateOnlyDE(this string input)
    {
        return DateOnly.Parse(input, _german, DateTimeStyles.None);
    }
}