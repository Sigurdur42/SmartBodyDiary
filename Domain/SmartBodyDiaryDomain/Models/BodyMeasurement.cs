namespace SmartBodyDiaryDomain;

public class BodyMeasurement : IDateRecord
{
    public BodyMeasurement()
    {
    }

    public BodyMeasurement(DateOnly day)
    {
        Day = day;
    }

    public DateOnly Day { get; init; }
    public decimal LeftArm { get; set; }
    public decimal RightArm { get; set; }
    public decimal LeftLeg { get; set; }
    public decimal RightLeg { get; set; }
    public decimal Shoulder { get; set; }
    public decimal Chest { get; set; }
    public decimal Belly { get; set; }
    public decimal BellyPlus5 { get; set; }
    public decimal BellyMinus5 { get; set; }
    public decimal Hip { get; set; }
}