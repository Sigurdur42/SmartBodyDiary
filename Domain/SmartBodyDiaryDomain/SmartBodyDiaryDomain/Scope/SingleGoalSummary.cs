using System.Diagnostics;

namespace SmartBodyDiaryDomain;

[DebuggerDisplay("R: {Reached} M: {Missed}")]
public class SingleGoalSummary
{
    public int Reached { get; internal set; }
    public int Missed { get; internal set; }

    public override bool Equals(object? obj)
    {
        if (obj is SingleGoalSummary rhs)
        {
            return Reached.Equals(rhs.Reached)
                   && Missed.Equals(rhs.Missed);
        }

        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Reached, Missed);
    }
}