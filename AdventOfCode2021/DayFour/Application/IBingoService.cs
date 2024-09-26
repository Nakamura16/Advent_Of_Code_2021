using DayFour.Model;

namespace DayFour.Application;

public interface IBingoService
{
    IList<int> PlayedNumbers { get; set; }

    int GetDayFourPartOneSolution(BingoCard card);
    BingoCard GetLastWinningBingoCard(IList<int> numbers, IList<BingoCard> cards);
    IList<int> GetUnmarkedNumbers(BingoCard card);
    BingoCard GetWinningBingoCard(IList<int> numbers, IList<BingoCard> cards);
}