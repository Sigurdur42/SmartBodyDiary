namespace SmartBodyDiaryDomain;

public interface ISbdWeightService
{
    void Calculate(DiaryWeight[] weightData, int rangeToConsider);
    SlidingWeight? GetWeight(DateOnly date);
}