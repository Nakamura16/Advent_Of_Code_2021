using DayTwo;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayTwo;

public class PartOneTests
{
    private readonly PartOne partOne = new();
    private readonly List<(string, int)> testData = new()
    {
        ("forward", 5),
        ("down", 5),
        ("forward", 8),
        ("up", 3),
        ("down", 8),
        ("forward", 2),
    };

    [Fact]
    public void Calculate_ShouldReturnTheMultiplicationOfHorizontalPositionAndDepthPosition()
    {
        var result = partOne.Calculate(testData);

        result.Should().Be(150);
    }
}
