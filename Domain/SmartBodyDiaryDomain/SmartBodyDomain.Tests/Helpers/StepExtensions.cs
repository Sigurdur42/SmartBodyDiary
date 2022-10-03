using System.Globalization;
using FluentAssertions;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests.Steps;

public static class StepExtensions
{
    public static readonly CultureInfo German = new("de-DE");
    public static readonly CultureInfo English = new("en-US");

    private static readonly Dictionary<string, Goal> _goalValues = Enum.GetValues<Goal>().ToDictionary(_ => _.ToString().ToLowerInvariant());
    private static readonly Dictionary<string, GymProgress> _progressValues = Enum.GetValues<GymProgress>().ToDictionary(_ => _.ToString().ToLowerInvariant());

    public static DateOnly ToDateOnlyDE(this string input)
        => DateOnly.Parse(input, German);

    public static decimal ToDecimalDE(this string input)
        => decimal.Parse(input, German);
    public static decimal ToInvariantDE(this string input)
        => decimal.Parse(input, CultureInfo.InvariantCulture);

    public static void FillFromReflection(this IDateRecord record, Table table)
    {
        var type = record.GetType();
        foreach (var row in table.Rows)
        {
            object? value = null;

            var propertyName = row[0];
            var property = type.GetProperty(propertyName);

            var propertyType = property?.PropertyType.Name.ToLowerInvariant();
            switch (propertyType)
            {
                case "string":
                    value = row[1];
                    break;

                case "decimal":
                    value = decimal.Parse(row[1], StepExtensions.English);
                    break;

                case "dateonly":
                    value = row[1].ToDateOnlyDE();
                    break;

                case "goal":
                    value = row[1].ToGoal();
                    break;

                default:
                    throw new InvalidCastException($"unexpected type '{propertyType}'");
            }

            property.Should().NotBeNull($"Cannot find property {propertyName} on type {type.FullName}");
            property?.SetValue(record, value);
        }
    }

    public static GymProgress ToGymProgress(this string input)
        => _progressValues[input.ToLowerInvariant()];

    public static Goal ToGoal(this string input)
        => string.IsNullOrWhiteSpace(input)
            ? Goal.Unknown
            : _goalValues[input.ToLowerInvariant()];

    public static T? FindByDate<T>(this IEnumerable<T> records, DateOnly date, bool expectedToFindRecord) where T : IDateRecord
    {
        var found = records.FirstOrDefault(_ => _.Day == date);
        if (!expectedToFindRecord)
        {
            found.Should().BeNull($"Do not expect record for {date} ({typeof(T)})");
        }
        else
        {
            found.Should().NotBeNull($"Cannot find record for {date} ({typeof(T)})");
        }

        return found;
    }
}