using Xunit;
using DayFour;
using FluentAssertions;

namespace Solutions.Test.DayFour;

public class BingoValidatorTests
{
    private readonly BingoValidator validator = new();

    [Fact]
    public void VerifyLine_WithAllLineCheckedAndCorrectBingoCardSize_ShouldReturnTrue()
    {
        var line = new List<Number>()
        {
            new(1,true), new(1,true) , new(1, true), new(1, true),new(1, true),
        };

        var result = validator.VerifyLine(line);

        result.Should().BeTrue();
    }

    [Fact]
    public void VerifyLine_WithAllLineCheckedAndInCorrectBingoCardSize_ShouldReturnFalse()
    {
        var line = new List<Number>()
        {
            new(1,true), new(1,true) , new(1, true)
        };

        var result = validator.VerifyLine(line);

        result.Should().BeFalse();
    }

    [Fact]
    public void VerifyLine_WithAnyElementUncheckedOnLine_ShouldReturnFalse()
    {
        var line = new List<Number>()
        {
            new(1,true), new(1,true) , new(1, true), new(1, false),new(1, true),
        };

        var result = validator.VerifyLine(line);

        result.Should().BeFalse();
    }
}
