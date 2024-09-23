using FluentAssertions;
using System.Runtime.CompilerServices;
using Xunit;

namespace DayThree.Test;

public class PartOneTests
{
    private readonly PartOne partOne = new();

    [Fact]
    public void Execute_ShouldReturnCorrectByteResult()
    {
        var testData = new List<string>()
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

        var result = partOne.Execute(testData);

        var expectedResult = "001101011100";
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void GetGammaRate_ShouldReturnCorrectByteResult()
    {
        var testData = new List<string>()
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

        var result = partOne.GetGammaRate(testData);

        var expectedResult = "001101011100";
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void GetEpsilonRate_ConvertToEpsilonRateCorrectly()
    {
        var gammaRate = "001101011100";
        var expectedResult = "110010100011";

        var result = partOne.GetEpsilonRate(gammaRate);

        result.Should().Be(expectedResult);
    }
}
