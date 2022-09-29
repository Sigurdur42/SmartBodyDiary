using System.Globalization;
using SmartBodyDomain;
using YamlDotNet.Serialization.NamingConventions;

namespace SmartBodyDiaryDomain.Import;

public class FitAndLiftImport
{
    public ImportResult Import(FileInfo fileInfo)
    {
        var result = new ImportResult();

        if (!fileInfo.Exists)
        {
            return result;
        }

        var content = File.ReadAllText(fileInfo.FullName);

        return Import(content);
    }

    private ImportResult Import(string fileContent)
    {
        var result = new ImportResult();

        var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();

        var readData = deserializer.Deserialize<ImportedData>(fileContent);

        result.Weights = readData.WeightRecords
            .Where(_ => _.WeightDecimal.HasValue)
            .Select(_ => new DiaryWeight(_.DateOnly, _.WeightDecimal!.Value)).ToArray();

        result.GymSessions = readData.WeightRecords
            .Where(_ => !string.IsNullOrWhiteSpace(_.GymSession) && _.GymSession != "None")
            .Select(_ => new GymSession(_.DateOnly)
            {
                Progress = _.GymSession switch
                {
                    "WithProgression" => GymProgress.Progress,
                    _ => GymProgress.Normal
                }
            }).ToArray();

        result.DailyGoals = readData.WeightRecords
            .Select(_ => new DailyGoals(_.DateOnly)
            {
                Kcal = ToGoal(_.KcalGoal),
                Sleep = ToGoal(_.SleepGoal),
                Macros = ToGoal(_.MacroGoal),
                Protein = ToGoal(_.MacroGoal),
                Neat = ToGoal(_.NeatGoal),
            })
            .Where(_ => !_.AllUnknown)
            .ToArray();

        result.Success = true;
        return result;
    }

    private Goal ToGoal(string input)
        => input switch
        {
            "Yes" => Goal.Reached,
            "No" => Goal.Missed,
            _ => Goal.Unknown
        };

    // ReSharper disable once ClassNeverInstantiated.Local
    private class ImportedData
    {
        public WeightRecord[] WeightRecords { get; set; } = Array.Empty<WeightRecord>();
    }

    // ReSharper disable once ClassNeverInstantiated.Local
    private class WeightRecord
    {
        private static readonly CultureInfo _german = new("De-de");
        private DateOnly? _dateOnly;
        private decimal? _weight;
        private bool _parsedDecimal;

        public DateOnly DateOnly
        {
            get
            {
                _dateOnly ??= DateOnly.Parse(Day, _german);
                return _dateOnly.Value;
            }
        }

        public decimal? WeightDecimal
        {
            get
            {
                if (!_parsedDecimal)
                {
                    if (!string.IsNullOrWhiteSpace(Weight))
                    {
                        _weight = decimal.Parse(Weight, _german);
                    }

                    _parsedDecimal = true;
                }

                return _weight;
            }
        }

        public string Day { get; set; } = "";
        public string Weight { get; set; } = "";
        public string GymSession { get; set; } = "";
        public string NeatGoal { get; set; } = "";
        public string KcalGoal { get; set; } = "";
        public string MacroGoal { get; set; } = "";
        public string SleepGoal { get; set; } = "";
    }
}