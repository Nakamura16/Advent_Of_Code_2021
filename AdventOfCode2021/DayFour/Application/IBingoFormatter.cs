using DayFour.Model;

namespace DayFour.Application;

public interface IBingoFormatter
{
    List<BingoCard> FormatBingoCards(IList<string> inputFile);
}