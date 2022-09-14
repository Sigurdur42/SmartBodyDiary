using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests;

// ReSharper disable once ClassNeverInstantiated.Global -> This is injected via reflection
public class SbdScenarioContext
{
    public SdbDateBasedRepository<Challenge> ChallengeRepository { get; set; } = new();
    public Challenge Challenge { get; set; } = new();
    public SdbDateBasedRepository<DiaryWeight> WeightRepository { get; set; } = new();

    public List<DiaryWeight> AvailableWeights { get; set; } = new();

    public CalculatedScope LastCalculatedScope { get; set; } = new();

    public SlidingWeightRepository SlidingWeightRepository { get; set; } = new();
    public ISbdWeightService? AverageWeightService { get; set; }
}