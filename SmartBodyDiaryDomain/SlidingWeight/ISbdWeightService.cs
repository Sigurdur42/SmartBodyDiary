namespace SmartBodyDiaryDomain;

public interface ISbdWeightService
{
    /// <summary>
    /// Calculates the sliding weight for all given weight records.
    /// <br/> The calculated weights are stored in the internal repository and can be retrieved
    /// via the <see cref="GetWeight"/> method.
    /// </summary>
    /// <param name="weightData">The weight records to calculate the sliding weight for.</param>
    /// <param name="rangeToConsider">
    /// The number of records (e. g. days) to consider as range for the sliding weight calculation.
    /// <br/> This is typically a week (7 days), a month or a challenge range.
    /// </param>
    void Calculate(DiaryWeight[] weightData, int rangeToConsider);

    SlidingWeight? GetWeight(DateOnly date);
}