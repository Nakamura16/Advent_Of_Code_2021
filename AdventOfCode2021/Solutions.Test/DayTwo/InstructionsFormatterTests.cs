using DayOne;
using DayTwo;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayTwo;

public class InstructionsFormatterTests
{
    private readonly InstructionsFormatter formatter = new();
    private readonly List<string> testData = new()
    {
        "forward 5",
        "down 5",
        "forward 8",
        "up 3",
        "down 8",
        "forward 2"
    };

    [Fact]
    public void TranformMeasurements_ShouldReturnTheTotalSumOfThreeMeasurementSliding()
    {
        var result = formatter.GetInstructions(testData);

        var expectedResult = new List<(string, int)>() 
        { 
            ("forward", 5),
            ("down", 5),
            ("forward", 8),
            ("up", 3),
            ("down", 8),
            ("forward", 2),
        };
        result.Should().BeEquivalentTo(expectedResult);
    }
}
