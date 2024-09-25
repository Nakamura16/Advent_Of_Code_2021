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
            new(1, true), new(1, true) , new(1, true), new(1, true),new(1, true),
        };

        var result = validator.VerifyLine(line);

        result.Should().BeTrue();
    }

    [Fact]
    public void VerifyLine_WithAllLineCheckedAndInCorrectBingoCardSize_ShouldReturnFalse()
    {
        var line = new List<Number>()
        {
            new(1, true), new(1, true) , new(1, true)
        };

        var result = validator.VerifyLine(line);

        result.Should().BeFalse();
    }

    [Fact]
    public void VerifyLine_WithAnyElementUncheckedOnLine_ShouldReturnFalse()
    {
        var line = new List<Number>()
        {
            new(1, true), new(1, true) , new(1, true), new(1, false),new(1, true),
        };

        var result = validator.VerifyLine(line);

        result.Should().BeFalse();
    }

    [Fact]
    public void VerifyColumn_WithAllCloumnCheckedAndCorrectBingoCardSize_ShouldReturnTrue()
    {
        var bingoCard = new List<List<Number>>()
        {
             new(){ new(1, true), new(1) },
             new(){ new(1, true), new(1) },
             new(){ new(1, true), new(1) },
             new(){ new(1, true), new(1) },
             new(){ new(1, true), new(1) },
        };

        var result = validator.VerifyColumn(bingoCard, 0);

        result.Should().BeTrue();
    }

    [Fact]
    public void VerifyColumn_WithAllCloumnCheckedAndInCorrectBingoCardSize_ShouldReturnFalse()
    {
        var bingoCard = new List<List<Number>>()
        {
             new(){ new(1), new(1, true) },
             new(){ new(1), new(1, true) },
             new(){ new(1), new(1, true) },
        };

        var result = validator.VerifyColumn(bingoCard, 1);

        result.Should().BeFalse();
    }

    [Fact]
    public void VerifyColumn_WithAnyElementUncheckedOnColumn_ShouldReturnFalse()
    {
        var bingoCard = new List<List<Number>>()
        {
             new(){ new(1), new(1, true) },
             new(){ new(1), new(1, false) },
             new(){ new(1), new(1, true) },
             new(){ new(1), new(1, true) },
             new(){ new(1), new(1, true) },
        };

        var result = validator.VerifyColumn(bingoCard, 1);

        result.Should().BeFalse();
    }
}
