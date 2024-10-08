using DaySix.Solution;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DaySix;

public class PartTwoSolutionManagerTests
{
    private readonly PartTwoSolutionManager solutionManager = new();

    [Fact]
    public void GetPartOneSolution_WithMoreDays_ShouldReturnCorrectValue()
    {
        var input = new List<string>() { "3,4,3,1,2" };

        var result = solutionManager.GetSolution(input, 256);

        result.Should().Be(26984457539);
    }
}
