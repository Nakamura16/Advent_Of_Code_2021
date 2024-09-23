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
        bitValidator.NumbersOnesQuantity = NumbersOnesQuantity;
        bitValidator.NumbersZeroQuantity= NumbersZeroQuantity;

        var result = bitValidator.ValidateQuantityOfNumbers();

        result.Should().Be(expectedResult);
        bitValidator.NumbersOnesQuantity.Should().Be(0);
        bitValidator.NumbersZeroQuantity.Should().Be(0);
    }

    [Fact]
    public void ValidateQuantityOfNumbers_WithTheSameAmountOfOnesAndZeros_ShoulThrowArgumentException()
    {
        var numberAmount = fixture.Create<int>();
        bitValidator.NumbersOnesQuantity = numberAmount;
        bitValidator.NumbersZeroQuantity = numberAmount;

        bitValidator.Invoking(b => b.ValidateQuantityOfNumbers())
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"The {nameof(BitValidator.NumbersOnesQuantity)} and "
                + $"{nameof(BitValidator.NumbersZeroQuantity)} are the same: "
                + $"\n\nNumbersOnesQuantity:{bitValidator.NumbersOnesQuantity} "
                + $"\nNumbersZeroQuantity:{bitValidator.NumbersZeroQuantity}");
    }
}
