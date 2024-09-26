using DayFour.Model;

namespace DayFour.Validator;

public interface IBingoValidator
{
    bool IsWinner(BingoCard card, int lastCheckedNumberLine, int lastCheckedNumberColumn);
    bool IsWinnerCard(int number, BingoCard card);
    bool IsWinnerCardValid(BingoCard winnercard);
    bool VerifyColumn(List<List<Number>> card, int columnPosition);
    bool VerifyLine(IList<Number> line);
}