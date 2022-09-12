namespace SmartBodyDiaryDomain;

public class SlidingWeight : IDateRecord
{
    public SlidingWeight()
    {
        
    }

    public SlidingWeight(DateOnly day, decimal weight)
    {
        Day = day;
        Weight = weight;
        Sliding = weight;
    }

    public decimal Weight { get; init; }
    public decimal Sliding { get; set; }
    public decimal SlidingRounded => Math.Round(Sliding, 2, MidpointRounding.AwayFromZero);

    public DateOnly Day { get; set; }
}