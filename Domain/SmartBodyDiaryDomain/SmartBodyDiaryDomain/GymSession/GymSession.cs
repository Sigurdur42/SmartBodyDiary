using SmartBodyDiaryDomain;

namespace SmartBodyDomain;

public enum GymProgress
{
    Normal = 0,
    Progress,
    Deload,
}

public class GymSession : IDateRecord
{
    public GymSession()
    {
    }

    public GymSession(DateOnly day)
    {
        day = Day;
    }

    public DateOnly Day { get; }

    public GymProgress Progress { get; set; }
}

