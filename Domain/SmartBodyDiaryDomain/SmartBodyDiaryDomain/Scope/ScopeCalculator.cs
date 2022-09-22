namespace SmartBodyDiaryDomain;

public class ScopeCalculator
{
    private readonly SdbDateBasedRepository<GymSession> _gymSessionRepository;
    private readonly SdbDateBasedRepository<SlidingWeight> _slidingWeightRepository;

    public ScopeCalculator(
        SdbDateBasedRepository<SlidingWeight> slidingWeightRepository,
        SdbDateBasedRepository<GymSession> gymSessionRepository)
    {
        _slidingWeightRepository = slidingWeightRepository;
        _gymSessionRepository = gymSessionRepository;
    }

    public CalculatedScope Calculate(DateOnly startDate, DateOnly endDate)
    {
        var result = new CalculatedScope();

        var allSliding = _slidingWeightRepository.GetAllData();
        var slidingData = allSliding
            .Where(_ => _.Day >= startDate && _.Day <= endDate)
            .OrderBy(_ => _.Day)
            .ToArray();

        result.WeightDiffSliding = slidingData.Length < 2
            ? 0.00m
            : slidingData.Last().SlidingRounded - slidingData.First().SlidingRounded;

        result.WeightDiff = slidingData.Length < 2
            ? 0.00m
            : slidingData.Last().Weight - slidingData.First().Weight;

        result.Weights = slidingData;

        result.GymSessions = _gymSessionRepository.GetAllData()
            .Where(_ => _.Day >= startDate && _.Day <= endDate)
            .OrderBy(_ => _.Day)
            .ToArray();

        return result;
    }
}