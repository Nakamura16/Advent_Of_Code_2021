using Xunit;
using FluentAssertions;

namespace DayThree.Test;

public class BitCounterTests
{
    private readonly BitCounter bitCounter = new();

    [Theory]
    [InlineData(10, 5, "1")]
    [InlineData(6, 10, "0")]
    [InlineData(7, 7, "1")]
    public void GetMostCommonBit_ShoulReturnMostCommonBit(
        int NumbersOnesQuantity,
        int NumbersZeroQuantity,
        string expectedResult)
    {
        bitCounter.OnesQuantity = NumbersOnesQuantity;
        bitCounter.ZerosQuantity= NumbersZeroQuantity;

        var result = bitCounter.GetMostCommonBit();

        result.Should().Be(expectedResult);
        bitCounter.OnesQuantity.Should().Be(0);
        bitCounter.ZerosQuantity.Should().Be(0);
    }
}
