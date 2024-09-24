using DayThree;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayThree;

public class PartOneTests
{
    private const string expectedGammaRate = "001101011100";
    private const string expectedEpsilonRate = "110010100011";

    private readonly PartOne partOne = new();
    private readonly List<string> testData = new()
    {
        "100101001000",
        "011101110101",
        "000001010101",
        "001001010001",
        "001101011110",
        "010101001100",
        "101100110101",
        "101010111110",
        "001100001000",
    };

    [Fact]
    public void Execute_ShouldReturnCorrectByteResult()
    {
        var result = partOne.Execute(testData);

        var expectedResult = 2782100;
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void GetGammaRate_ShouldReturnCorrectByteResult()
    {
        var result = partOne.GetGammaRate(testData);

        result.Should().Be(expectedGammaRate);
    }

    [Fact]
    public void GetEpsilonRate_ConvertToEpsilonRateCorrectly()
    {
        var result = partOne.GetEpsilonRate(expectedGammaRate);

        result.Should().Be(expectedEpsilonRate);
    }

    [Fact]
    public void GetEpsilonRate_WithInvalidBit_ShouldThrowException()
    {
        var result = partOne.Invoking(p => p.GetEpsilonRate("2"))
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("Cannot Convert Epsilon Rate.");
    }
}
