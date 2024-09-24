using Xunit;
using DayThree;
using FluentAssertions;
using AutoFixture;

namespace DayThree.Test;

public class BitValidatorTests
{
    private readonly Fixture fixture = new();
    private readonly BitCounter bitValidator = new();

    [Theory]
    [InlineData(10, 5, "1")]
    [InlineData(6, 10, "0")]
    [InlineData(7, 7, "1")]
    public void ValidateQuantityOfNumbers_ShoulReturnMostCommonNumber(
        int NumbersOnesQuantity,
        int NumbersZeroQuantity,
        string expectedResult)
    {
        bitValidator.OnesQuantity = NumbersOnesQuantity;
        bitValidator.ZerosQuantity= NumbersZeroQuantity;

        var result = bitValidator.GetBitValue();

        result.Should().Be(expectedResult);
        bitValidator.OnesQuantity.Should().Be(0);
        bitValidator.ZerosQuantity.Should().Be(0);
    }
}
