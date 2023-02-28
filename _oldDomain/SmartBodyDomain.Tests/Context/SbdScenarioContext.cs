using SmartBodyDiaryDomain;
using SmartBodyDiaryDomain.Import;

namespace SmartBodyDomain.Tests;

// ReSharper disable once ClassNeverInstantiated.Global -> This is injected via reflection
public class SbdScenarioContext
{
    public Challenge Challenge { get; set; } = new();

    public SdbDateBasedRepository<Challenge> ChallengeRepository { get; set; } = new();
    public SdbDateBasedRepository<DiaryWeight> WeightRepository { get; set; } = new();
    public SdbDateBasedRepository<GymSession> GymSessionRepository { get; set; } = new();
    public SdbDateBasedRepository<DailyGoals> DailyGoalsRepository { get; set; } = new();

    public List<DiaryWeight> AvailableWeights { get; set; } = new();

    public CalculatedScope LastCalculatedScope { get; set; } = new();

    public SlidingWeightRepository SlidingWeightRepository { get; set; } = new();
    public ISbdWeightService? AverageWeightService { get; set; }
    public ImportResult FitAndLiftImportResult { get; set; } = new();
}