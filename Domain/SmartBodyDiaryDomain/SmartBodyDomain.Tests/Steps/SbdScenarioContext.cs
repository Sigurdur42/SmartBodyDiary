using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests;

public class SbdScenarioContext
{
    public SdbDateBasedRepository<Challenge> ChallengeRepository { get; set; } = new();
    public Challenge Challenge { get; set; } = new();
    public SdbDateBasedRepository<DiaryWeight> WeightRepository { get; set; } = new();
}