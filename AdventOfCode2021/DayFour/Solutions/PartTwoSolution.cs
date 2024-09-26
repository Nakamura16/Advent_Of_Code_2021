using DayFour.Application;

namespace DayFour.Solutions;

public class PartTwoSolution
{
    private readonly IBingoFormatter formatter;
    private readonly IBingoService service;

    public PartTwoSolution(IBingoFormatter formatter, IBingoService service)
    {
        this.formatter = formatter;
        this.service = service;
    }

    public int ExecuteSolution(IList<string> file)
    {
        List<int> bingoNumbers = formatter.GetBingoNumbers(file);

        var bingoCards = formatter.FormatBingoCards(file);

        var winningCard = service.GetLastWinningBingoCard(bingoNumbers, bingoCards);
        return service.GetProductOfTheSumOfUnmarkedNumbersAndTheLastPlayedNumber(winningCard);
    }
}
