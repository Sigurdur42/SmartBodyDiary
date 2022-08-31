using FluentAssertions;

namespace SmartBodyDomain.Tests;

[Binding]
public class SbdGymSessionRepositorySteps
{
    private SbdGymSessionRepository _repository = new(); 
    
    [Given(@"An empty gym session repository is initialized")]
    public void GivenAnEmptyGymSessionRepositoryIsInitialized()
    {
        _repository = new SbdGymSessionRepository();
    }

    [Then(@"Exactly '(.*)' gym session\(s\) is in the repository")]
    public void ThenExactlyGymSessionSIsInTheRepository(int numberOfSessions)
    {
        var result = _repository.Length;
        result.Should().Be(numberOfSessions);
    }

    [Then(@"A gym session is added at '(.*)' with status '(.*)'")]
    [Given(@"A gym session is added at '(.*)' with status '(.*)'")]
    public void GivenAGymSessionIsAddedAt(DateOnly day, GymProgress status)
    {
        var gym = new GymSession(day)
        {
            Progress = status
        };
        _repository.AddOrUpdate(day, gym);
    }

    [Then(@"The gym status on '(.*)' is '(.*)'")]
    public void ThenTheGymStatusOnIs(DateOnly day, GymProgress progress)
    {
        var result = _repository.Get(day);
        result?.Progress.Should().Be(progress);
    }
}