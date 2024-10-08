using DaySix.Application;
using DaySix.Factory;
using DaySix.Model;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DaySix;

public class FishConverterTests
{
    private readonly LanternFishFactory factory = new();
    private readonly FishConverter formatter;

    public FishConverterTests()
    {
        formatter = new(factory);
    }

    [Fact]
    public void CreateExistingFishes_ShouldReturnAllLanternFishesWihCorrectDaysToReproduce()
    {
        var input = new List<string>() { "3,4,3,1,2" };

        var result = formatter.ConvertFish(input);

        var expectedResult = new List<LanternFish>()
        {
            new(3),
            new(4),
            new(3),
            new(1),
            new(2),
        };
        result.Should().BeEquivalentTo(expectedResult);
    }
}
