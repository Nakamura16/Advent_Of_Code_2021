using DaySix.Model;
using DaySix.Solution;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DaySix;

public class PartOneSolutionManagerTests
{
    private readonly PartOneSolutionManager solutionManager = new();

    [Fact]
    public void GetPartOneSolution_WithMoreDays_ShouldReturnCorrectValue()
    {
        var input = new List<string>() { "3,4,3,1,2" };

        var result = solutionManager.GetSolution(input, 18);

        result.Should().Be(26);
    }

    [Fact]
    public void GetPartOneSolution_WithExemple_ShouldReturnCorrectValue()
    {
        var input = new List<string>() { "3,4,3,1,2" };

        var result = solutionManager.GetSolution(input, 80);

        result.Should().Be(5934);
    }

    [Fact]
    public void ReduceDay_ShouldReduceAllFishDaysByOne()
    {
        var fishToReduce = new List<LanternFish>() { new(1), new(5), new(3) };

        solutionManager.ReduceDay(fishToReduce);

        var expectedResult = new List<LanternFish>() { new(0), new(4), new(2) };
        fishToReduce.Should().BeEquivalentTo(expectedResult);
    }
}
