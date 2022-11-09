namespace SmartBodyDiaryDomain;

public class Challenge : IDateRecord
{
    public Challenge()
    {
    }

    public Challenge(DateOnly day)
    {
        Day = day;
    }

    public DateOnly Day { get; init; }
    public string Title { get; set; } = "";
    public DateOnly Start { get; set; } = DateOnly.MinValue;
    public DateOnly End { get; set; } = DateOnly.MinValue;

    public bool IsActive(DateOnly referenceDay)
        => Start <= referenceDay && End >= referenceDay;
}