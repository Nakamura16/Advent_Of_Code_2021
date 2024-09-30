using DayFour.Model;

namespace DayFour.Application;

public interface IBingoService
{
    IList<int> PlayedNumbers { get; set; }

    int GetProductOfTheSumOfUnmarkedNumbersAndTheLastPlayedNumber(BingoCard card);
    BingoCard GetLastWinningBingoCard(IList<int> numbers, IList<BingoCard> cards);
    List<int> GetUnmarkedNumbers(BingoCard card);
    BingoCard GetWinningBingoCard(IList<int> numbers, IList<BingoCard> cards);
}