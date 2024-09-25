namespace DayFour;

public class PartOneSolution
{
    public int ExecuteSolution(IList<string> file)
    {
        List<int> bingoNumbers = GetBingoNumbers(file);

        var bingoCards = new BingoFormatter().FormatBingoCards(file);

        var service = new BingoService();
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
