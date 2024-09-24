using DayTwo;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayTwo;

public class PartTwoTests
{
    private readonly PartTwo partTwo = new();
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
    public void Calculate_ShouldReturnTheMultiplicationOfHorizontalPositionAndDepthPositionConsideringAim()
    {
        var result = partTwo.Calculate(testData);

        result.Should().Be(900);
    }
}
