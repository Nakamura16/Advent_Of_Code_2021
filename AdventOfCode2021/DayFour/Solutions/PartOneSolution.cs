using DayFour.Application;
using DayFour.Application.Impl;

namespace DayFour.Solutions;

public class PartOneSolution
{
    // SOLID - Dependency Inversion
    // "Depend on abstractions"
    private readonly IBingoFormatter formatter;
    private readonly IBingoService service;

    public PartOneSolution(IBingoFormatter formatter, IBingoService service)
    {
        this.formatter = formatter;
        this.service = service;
    }

    public int ExecuteSolution(IList<string> file)
    {
        List<int> bingoNumbers = formatter.GetBingoNumbers(file);

        var bingoCards = formatter.FormatBingoCards(file);

        var winningCard = service.GetWinningBingoCard(bingoNumbers, bingoCards);
        return service.GetProductOfTheSumOfUnmarkedNumbersAndTheLastPlayedNumber(winningCard);
    }
}
