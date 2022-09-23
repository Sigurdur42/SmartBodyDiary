using SmartBodyDomain;

namespace SmartBodyDiaryDomain;

public class ScopeCalculator
{
    private readonly SdbDateBasedRepository<GymSession> _gymSessionRepository;
    private readonly SdbDateBasedRepository<SlidingWeight> _slidingWeightRepository;
    private readonly SdbDateBasedRepository<DailyGoals> _dailyGoalsRepository;

    public ScopeCalculator(
        SdbDateBasedRepository<SlidingWeight> slidingWeightRepository,
        SdbDateBasedRepository<GymSession> gymSessionRepository,
        SdbDateBasedRepository<DailyGoals> dailyGoalsRepository)
    {
        _slidingWeightRepository = slidingWeightRepository;
        _gymSessionRepository = gymSessionRepository;
        _dailyGoalsRepository = dailyGoalsRepository;
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

        result.DailyGoals = new DailyGoalsSummary(_dailyGoalsRepository.GetAllData().Where(_ => _.Day >= startDate && _.Day <= endDate));

        return result;
    }
}