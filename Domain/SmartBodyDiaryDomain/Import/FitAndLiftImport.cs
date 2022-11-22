using System.Globalization;
using SmartBodyDomain;
using YamlDotNet.Serialization.NamingConventions;

namespace SmartBodyDiaryDomain.Import;

public class FitAndLiftImport
{
    private static readonly CultureInfo _german = new("De-de");
    private static readonly CultureInfo _invariant = CultureInfo.InvariantCulture;
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

        result.Challenges = readData.ChallengeModels
            .Select(_ => new Challenge(_.StartOnly)
            {
                Start = _.StartOnly,
                End = _.EndOnly,
                Title = _.Name,
            })
            .ToArray();

        result.BodyData = readData.BodyRecords
            .Select(_ => new BodyMeasurement(_.DateOnly)
            {
                LeftArm = decimal.Parse(_.ArmLeft, _invariant),
                RightArm = decimal.Parse(_.ArmRight, _invariant),
                Belly = decimal.Parse(_.Belly, _invariant),
                BellyPlus5 = decimal.Parse(_.BellyPlus5, _invariant),
                BellyMinus5 = decimal.Parse(_.BellyMinus5, _invariant),
                Chest = decimal.Parse(_.Chest, _invariant),
                Hip =  decimal.Parse(_.Hip, _invariant),
                LeftLeg =  decimal.Parse(_.UpperLegLeft, _invariant),
                RightLeg =  decimal.Parse(_.upperLegRight, _invariant),
                Shoulder =  decimal.Parse(_.Shoulder, _invariant),
            })
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
        public ChallengeRecord[] ChallengeModels { get; set; } = Array.Empty<ChallengeRecord>();
        public BodyRecord[] BodyRecords { get; set; } = Array.Empty<BodyRecord>();
    }

    private class BodyRecord
    {
        private static readonly CultureInfo _german = new("De-de");
        private DateOnly? _dateOnly;

        public DateOnly DateOnly
        {
            get
            {
                _dateOnly ??= DateOnly.Parse(Day, _german);
                return _dateOnly.Value;
            }
        }

        public string Day { get; set; } = "";
        public string ArmLeft { get; set; } = "";
        public string ArmRight { get; set; } = "";
        public string UpperLegLeft { get; set; } = "";
        public string upperLegRight { get; set; } = "";
        public string Chest { get; set; } = "";
        public string Hip { get; set; } = "";
        public string Shoulder { get; set; } = "";
        public string Belly { get; set; } = "";
        public string BellyPlus5 { get; set; } = "";
        public string BellyMinus5 { get; set; } = "";
    }

    // ReSharper disable once ClassNeverInstantiated.Local
    private class ChallengeRecord
    {
        private static readonly CultureInfo _german = new("De-de");
        private DateOnly? _startOnly;
        private DateOnly? _endOnly;

        public string Start { get; set; } = "";
        public string End { get; set; } = "";
        public string Name { get; set; } = "";

        public DateOnly StartOnly
        {
            get
            {
                _startOnly ??= DateOnly.Parse(Start, _german);
                return _startOnly.Value;
            }
        }

        public DateOnly EndOnly
        {
            get
            {
                _endOnly ??= DateOnly.Parse(End, _german);
                return _endOnly.Value;
            }
        }
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
                        // _weight = decimal.Parse(Weight, _german);
                        _weight = decimal.Parse(Weight, CultureInfo.InvariantCulture);
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