using DayOne;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayOne;

public class PartOneSolutionTests
{
    private readonly PartOneSolution partOneSolution = new();
    private readonly List<int> testData = new() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

    [Fact]
    public void Run_ShouldReturnHowManyMeasurementsAreBiggerThanPrevious()
    {
        var result = partOneSolution.Run(testData);

        result.Should().Be(7);
    }
}
