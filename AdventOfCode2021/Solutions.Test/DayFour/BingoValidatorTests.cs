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

    [Fact]
    public void IsWinner_WithWinningCardOnLine_ShouldReturnTrue()
    {
        var bingoCard = new BingoCard(new List<List<Number>>()
        {
            new (){ new(1, true), new(1, true) , new(1, true), new(1, true),new(1, true)}
        });

        var result = validator.IsWinner(bingoCard, 0, 3);

        result.Should().BeTrue();
    }

    [Fact]
    public void IsWinner_WithWinningCardOnColumn_ShouldReturnTrue()
    {
        var bingoCard = new BingoCard( 
            new List<List<Number>>()
            {
                 new(){ new(1, true), new(1) },
                 new(){ new(1, true), new(1) },
                 new(){ new(1, true), new(1) },
                 new(){ new(1, true), new(1) },
                 new(){ new(1, true), new(1) },
            });

        var result = validator.IsWinner(bingoCard, 3, 0);

        result.Should().BeTrue();
    }

    [Fact]
    public void IsWinner_WithNonWinningCard_ShouldReturnFalse()
    {
        var bingoCard = new BingoCard(
            new List<List<Number>>()
            {
                 new(){ new(1, true), new(1) },
                 new(){ new(1, true), new(1) },
                 new(){ new(1, false), new(1) },
                 new(){ new(1, true), new(1) },
                 new(){ new(1, true), new(1) },
            });

        var result = validator.IsWinner(bingoCard, 3, 0);

        result.Should().BeFalse();
    }

    [Fact]
    public void IsWinnerCard_WithWinningCardOnColumn_ShouldReturnTrue()
    {
        var bingoCard = new BingoCard(
            new List<List<Number>>()
            {
                new(){ new(1, true), new(6) },
                new(){ new(2, true), new(7) },
                new(){ new(3, false), new(8) },
                new(){ new(4, true), new(9) },
                new(){ new(5, true), new(10) },
            });

        var result = validator.IsWinnerCard(3, bingoCard);

        result.Should().BeTrue();
        bingoCard.numbers[2].Should().ContainSingle(number => number.Value == 3).Which.IsChecked.Should().BeTrue();
    }

    [Fact]
    public void IsWinnerCard_WithWinningCardOnLine_ShouldReturnTrue()
    {
        var bingoCard = new BingoCard(new List<List<Number>>()
        {
            new (){ new(1, true), new(2, true) , new(3, false), new(4, true),new(5, true)}
        });

        var result = validator.IsWinnerCard(3, bingoCard);

        result.Should().BeTrue();
        bingoCard.numbers.Single().Should().ContainSingle(number => number.Value == 3).Which.IsChecked.Should().BeTrue();
    }

    [Fact]
    public void IsWinnerCard_WithNonWinningCard_ShouldReturnFalse()
    {
        var bingoCard = new BingoCard(
            new List<List<Number>>()
            {
                new(){ new(1, true), new(6) },
                new(){ new(2, false), new(7) },
                new(){ new(3, false), new(8) },
                new(){ new(4, true), new(9) },
                new(){ new(5, true), new(10) },
            });

        var result = validator.IsWinnerCard(3, bingoCard);

        result.Should().BeFalse();
        bingoCard.numbers[1].Should().ContainSingle(number => number.Value == 2).Which.IsChecked.Should().BeFalse();
        bingoCard.numbers[2].Should().ContainSingle(number => number.Value == 3).Which.IsChecked.Should().BeTrue();
    }

    [Fact]
    public void VerifyBingoCards_WithOneWinningBingoCard_ShouldReturnWinnerCard()
    {
        var numbers = new List<int>() { 1, 2, 3, 4, 5 };
        var bingoCards = new List<BingoCard>()
        {
            new(new()
            {
                new(){ new(0), new(0) },
                new(){ new(0), new(0) },
                new(){ new(0), new(0) },
                new(){ new(0), new(0) },
                new(){ new(0), new(0) },
            }),

            new(new()
            {
                new(){ new(1), new(6) },
                new(){ new(2), new(7) },
                new(){ new(3), new(8) },
                new(){ new(4), new(9) },
                new(){ new(5), new(10) },
            })
        };

        var result = validator.GetWinningBingoCard(numbers, bingoCards);

        var expectedResult = new BingoCard(
            new()
            {
                new(){ new(1, true), new(6) },
                new(){ new(2, true), new(7) },
                new(){ new(3, true), new(8) },
                new(){ new(4, true), new(9) },
                new(){ new(5, true), new(10) },
            });
        result.Should().BeEquivalentTo(expectedResult);
        validator.playedNumbers.Should().BeEquivalentTo(numbers);
    }
}
