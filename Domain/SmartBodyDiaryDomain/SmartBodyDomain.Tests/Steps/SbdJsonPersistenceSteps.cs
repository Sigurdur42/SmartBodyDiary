using FluentAssertions;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests;

[Binding]
public class SbdJsonPersistenceSteps
{
    private readonly JsonPersistenceContainer _containerToBeUsed = new JsonPersistenceContainer();
    private  JsonPersistenceContainer _containerDeserialized = new JsonPersistenceContainer();
   
    private JsonPersistence _persistence = new();
    private string _serializedJson = "";
    
   

    [Given(@"The DiaryWeight JSON persistence is create")]
    public void GivenTheDiaryWeightJsonPersistenceIsCreate()
    {
        _persistence = new JsonPersistence
        {
            WriteIndented = true
        };
    }

    [When(@"These DiaryWeight records shall be used")]
    public void WhenTheseDiaryWeightRecordsShallBeUsed(IEnumerable<DiaryWeight> existingData)
    {
        _containerToBeUsed.Weights = existingData.ToArray();
    }

    [When(@"The data is written to JSON")]
    public void WhenDiaryWeightDataIsWrittenToJson()
    {
        _serializedJson = _persistence.Serialize(_containerToBeUsed);
    }

    [When(@"The data is read from JSON")]
    public void WhenDiaryWeightDataIsReadFromJson()
    {
        _containerDeserialized = _persistence.Deserialize(_serializedJson) ?? new JsonPersistenceContainer();
    }

    [Then(@"The previous existing weight records shall be read")]
    public void ThenThePreviousExistingWeightRecordsShallBeRead()
    {
        _containerDeserialized.Weights
            .OrderBy(_ => _.Day)
            .Should().BeEquivalentTo(_containerToBeUsed.Weights.OrderBy(_ => _.Day));
    }

    [When(@"These GymSession records shall be used")]
    public void WhenTheseGymSessionRecordsShallBeUsed(IEnumerable<GymSession> sessions)
    {
        _containerToBeUsed.GymSessions = sessions.ToArray();
    }

    [Then(@"The previous existing gym session records shall be read")]
    public void ThenThePreviousExistingGymSessionRecordsShallBeRead()
    {
        _containerDeserialized.GymSessions
            .OrderBy(_ => _.Day)
            .Should().BeEquivalentTo(_containerToBeUsed.GymSessions.OrderBy(_ => _.Day));
    }
}