using FluentAssertions;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests;

[Binding]
public class SbdJsonPersistenceSteps
{
    private JsonPersistence _persistence = new();
    private DiaryWeight[] _weightsToBeUsed = Array.Empty<DiaryWeight>();
    private DiaryWeight[] _weightsDeserialized = Array.Empty<DiaryWeight>();
    private string _serializedJson = "";
    
    [Given(@"The DiaryWeight JSON persistence is create")]
    public void GivenTheDiaryWeightJsonPersistenceIsCreate()
    {
        _persistence = new JsonPersistence();
    }

    [When(@"These DiaryWeight records shall be used")]
    public void WhenTheseDiaryWeightRecordsShallBeUsed(IEnumerable<DiaryWeight> existingData)
    {
        _weightsToBeUsed = existingData.ToArray();
    }

    [When(@"DiaryWeight data is written to JSON")]
    public void WhenDiaryWeightDataIsWrittenToJson()
    {
        _serializedJson = _persistence.Serialize(_weightsToBeUsed);
    }

    [When(@"DiaryWeight data is read from JSON")]
    public void WhenDiaryWeightDataIsReadFromJson()
    {
        _weightsDeserialized = _persistence.Deserialize(_serializedJson);
    }

    [Then(@"The previous existing weight records shall be read")]
    public void ThenThePreviousExistingWeightRecordsShallBeRead()
    {
        _weightsToBeUsed
            .OrderBy(_ => _.Day)
            .Should().BeEquivalentTo(_weightsDeserialized.OrderBy(_ => _.Day));
    }
}