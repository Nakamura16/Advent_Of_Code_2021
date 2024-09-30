using DayFour.Model;

namespace DayFour.Application;

public interface IBingoFormatter
{
    List<BingoCard> FormatBingoCards(IList<string> inputFile);
    List<int> GetBingoNumbers(IList<string> file);
}