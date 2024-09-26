using DayFour.Application;
using DayFour.Application.Impl;

namespace DayFour.Solutions;

public class PartOneSolution
{
    // SOLID - Dpendency Inversion
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
        List<int> bingoNumbers = GetBingoNumbers(file);

        var bingoCards = formatter.FormatBingoCards(file);

        var winningCard = service.GetWinningBingoCard(bingoNumbers, bingoCards);
        return service.GetDayFourPartOneSolution(winningCard);
    }

    private List<int> GetBingoNumbers(IList<string> file)
    {
        return file
            .Single(line => line.Length > 15)
            .Split(",")
            .Select(number => int.Parse(number))
            .ToList();
    }
}
