namespace SmartBodyDiaryDomainTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
    }

    [Theory]
    [InlineData(2)]
    public void Test2(int data)
    {
        Assert.Equal(2, data);
    }
}