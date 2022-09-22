using FluentAssertions;
using SmartBodyDiaryDomain;

namespace SmartBodyDomain.Tests;

[Binding]
public class SbdGymSessionRepositorySteps
{
    private readonly SbdScenarioContext _context;

    public SbdGymSessionRepositorySteps(SbdScenarioContext context)
    {
        _context = context;
    }

    [Given(@"An empty gym session repository is initialized")]
    public void GivenAnEmptyGymSessionRepositoryIsInitialized()
    {
        _context.GymSessionRepository = new SdbDateBasedRepository<GymSession>();
    }

    [Then(@"Exactly '(.*)' gym session\(s\) is in the repository")]
    public void ThenExactlyGymSessionSIsInTheRepository(int numberOfSessions)
    {
        var result = _context.GymSessionRepository.Length;
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
        _context.GymSessionRepository.AddOrUpdate(gym);
    }

    [Then(@"The gym status on '(.*)' is '(.*)'")]
    public void ThenTheGymStatusOnIs(DateOnly day, GymProgress progress)
    {
        var result = _context.GymSessionRepository.Get(day);
        result?.Progress.Should().Be(progress);
    }

    [Given(@"These gym sessions are available")]
    public void GivenThesegymsessionsareavailable(IEnumerable<GymSession> existingData)
    {
        _context.GymSessionRepository.AddOrUpdateRange(existingData);
    }
}