using DayFour.Model;

namespace DayFour.Validator;

public class BingoValidator
{
    private const int bingoCardSize = 5;

    public bool IsWinnerCard(int number, BingoCard card)
    {
        var cardNumbers = card.Numbers;
        for (int line = 0; line < cardNumbers.Count; line++)
        {
            for (int column = 0; column < cardNumbers[line].Count; column++)
            {
                if (cardNumbers[line][column].Value == number)
                {
                    cardNumbers[line][column].IsChecked = true;
                    return IsWinner(card, line, column);
                }
            }
        }
        return false;
    }

    public bool IsWinner(BingoCard card, int lastCheckedNumberLine, int lastCheckedNumberColumn)
    {
        var cardNumbers = card.Numbers;
        return VerifyLine(cardNumbers[lastCheckedNumberLine])
            || VerifyColumn(cardNumbers, lastCheckedNumberColumn);
    }

    public bool VerifyLine(List<Number> line)
    {
        return line.Where(item => item.IsChecked).Count() == bingoCardSize;
    }

    public bool VerifyColumn(List<List<Number>> card, int columnPosition)
    {
        var column = new List<Number>();
        foreach (var line in card)
        {
            if (line[columnPosition].IsChecked)
            {
                column.Add(line[columnPosition]);
            }
        }
        return column.Count == bingoCardSize;
    }
}
