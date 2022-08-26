namespace SmartBodyDiaryDomain;

public interface ISbdWeightService
{
    void Calculate(DiaryWeight[] weightData);
    SlidingWeight? GetWeight(DateOnly date);
}