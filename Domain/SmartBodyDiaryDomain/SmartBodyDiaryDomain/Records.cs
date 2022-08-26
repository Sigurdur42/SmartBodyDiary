namespace SmartBodyDiaryDomain;

public record DiaryWeight(DateOnly Day, decimal Weight);

public record AverageWeight (DateOnly Day, decimal Weight)
{
    public decimal Average { get; set; } = Weight;
    public decimal AverageRounded => Math.Round(Average, 2, MidpointRounding.AwayFromZero);
}