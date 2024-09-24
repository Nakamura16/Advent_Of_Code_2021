using FluentAssertions;
using Xunit;

namespace DayThree.Test;

public class PartTwoTests
{
    private readonly PartTwo partTwo = new();
    private readonly List<string> testData = new()
    {
        "00100",
        "11110",
        "10110",
        "10111",
        "10101",
        "01111",
        "00111",
        "11100",
        "10000",
        "11001",
        "00010",
        "01010"
    };

    [Fact]
    public void GetOxygenGeneratorRating_ShouldReturnTheMostCommonValue()
    {
        var result = partTwo.GetOxygenGeneratorRating(testData);

        result.Should().Be("10111");
    }

    [Fact]
    public void RemoveNumbers_ShouldRemoveTheCorrectNumbers()
    {
        var result = partTwo.RemoveNumbers(bytes: testData, column: 3, bitToRemove: "1");

        var expectedResult = new List<string>()
        {
            "10000",
            "11001",
            "00010",
            "01010"
        };

        result.Should().BeEquivalentTo(expectedResult);
    }
}
