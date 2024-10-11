using DaySeven;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DaySeven;

public class PartOneSolutionTests
{
    private readonly InputConverter converter = new();
    private readonly PartOneSolution solution;

    public PartOneSolutionTests()
    {
        solution = new(converter);
    }

    [Fact]
    public void GetSolution_WithExampleInput_ShouldReturnCorrectSolution()
    {
        var input = new List<string>() { "16,1,2,0,4,2,7,1,2,14" };

        var result = solution.GetSolution(input);

        result.Should().Be(37);
    }
}
