using DayFour;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayFour;

public class BingoServiceTests
{
    private readonly BingoService service = new();

    [Fact]
    public void VerifyBingoCards_WithWinningCard_ShouldReturnCorrectWinnerCard()
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

        var result = service.GetWinningBingoCard(numbers, bingoCards);

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
        service.PlayedNumbers.Should().BeEquivalentTo(numbers);
    }

    [Fact]
    public void VerifyBingoCards_WithoutWinningCards_ShouldThrowException()
    {
        var numbers = new List<int>() { 1, 2, 3, 4, 5 };
        var bingoCards = new List<BingoCard>();

        var result = service
            .Invoking(s => s.GetWinningBingoCard(numbers, bingoCards))
            .Should()
            .ThrowExactly<InvalidDataException>()
            .WithMessage("There is no Winning Cards.");
    }

    [Fact]
    public void GetUnmarkedNumbers_ShouldReturnCorrectUnmarkedNumbers()
    {
        service.PlayedNumbers = new List<int>() { 1, 3, 4, 5, 9};
        var bingoCard = new BingoCard(
            new()
            {
                new(){ new(1, true), new(6) },
                new(){ new(2), new(7) },
                new(){ new(3, true), new(8) },
                new(){ new(4, true), new(9, true) },
                new(){ new(5, true), new(10) },
            });

        var result = service.GetUnmarkedNumbers(bingoCard);

        var expectedResult = new List<int>() {2, 6, 7, 8, 10 };
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void GetDayFourPartOneSolution_ShouldReturnCorrectSolution()
    {
        service.PlayedNumbers = new List<int>() { 1, 3, 4, 5, 9 };
        var bingoCard = new BingoCard(
            new()
            {
                new(){ new(1, true), new(6) },
                new(){ new(2), new(7) },
                new(){ new(3, true), new(8) },
                new(){ new(4, true), new(9, true) },
                new(){ new(5, true), new(10) },
            });

        var result = service.GetDayFourPartOneSolution(bingoCard);

        result.Should().Be(33 * 9);
    }
}
