using Xunit;
using DayThree;
using FluentAssertions;
using AutoFixture;

namespace DayThree.Test;

public class BitValidatorTests
{
    private readonly Fixture fixture = new();
    private readonly BitValidator bitValidator = new();

    [Theory]
    [InlineData(10, 5, "1")]
    [InlineData(6, 10, "0")]
    public void ValidateQuantityOfNumbers_ShoulReturnMostCommonNumber(
        int NumbersOnesQuantity,
        int NumbersZeroQuantity,
        string expectedResult)
    {
        bitValidator.OnesQuantity = NumbersOnesQuantity;
        bitValidator.ZerosQuantity= NumbersZeroQuantity;

        var result = bitValidator.ValidateQuantityOfNumbers();

        result.Should().Be(expectedResult);
        bitValidator.OnesQuantity.Should().Be(0);
        bitValidator.ZerosQuantity.Should().Be(0);
    }

    [Fact]
    public void ValidateQuantityOfNumbers_WithTheSameAmountOfOnesAndZeros_ShoulThrowArgumentException()
    {
        var numberAmount = fixture.Create<int>();
        bitValidator.OnesQuantity = numberAmount;
        bitValidator.ZerosQuantity = numberAmount;

        bitValidator.Invoking(b => b.ValidateQuantityOfNumbers())
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"The {nameof(BitValidator.OnesQuantity)} and "
                + $"{nameof(BitValidator.ZerosQuantity)} are the same: "
                + $"\n\nNumbersOnesQuantity:{bitValidator.OnesQuantity} "
                + $"\nNumbersZeroQuantity:{bitValidator.ZerosQuantity}");
    }
}
