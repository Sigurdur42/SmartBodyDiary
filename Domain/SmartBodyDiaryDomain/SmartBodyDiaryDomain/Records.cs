namespace SmartBodyDiaryDomain;

public record SlidingWeight(DateOnly Day, decimal Weight) : IDateRecord
{
    public decimal Sliding { get; set; } = Weight;
    public decimal SlidingRounded => Math.Round(Sliding, 2, MidpointRounding.AwayFromZero);
}