namespace SmartBodyDiaryDomain;

public record DiaryWeight(DateOnly Day, decimal Weight);

public record SlidingWeight (DateOnly Day, decimal Weight)
{
    public decimal Sliding { get; set; } = Weight;
    public decimal SlidingRounded => Math.Round(Sliding, 2, MidpointRounding.AwayFromZero);
}