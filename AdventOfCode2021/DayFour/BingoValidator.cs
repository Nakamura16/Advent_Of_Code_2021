namespace DayFour;

public class BingoValidator
{
    private const int bingoCardSize = 5;

    public bool IsWinnerCard(int number, BingoCard card)
    {
        var bingoCard = card.numbers;
        for (int line = 0; line < bingoCard.Count; line++)
        {
            for (int column = 0; column < bingoCard[line].Count; column++)
            {
                if (bingoCard[line][column].Value == number)
                {
                    bingoCard[line][column].IsChecked = true;
                    return IsWinner(card, line, column);
                }
            }
        }
        return false;
    }

    public bool IsWinner(BingoCard card, int lastCheckedNumberLine, int lastCheckedNumberColumn)
    {
        var bingoCard = card.numbers;
        return VerifyLine(bingoCard[lastCheckedNumberLine]) 
            || VerifyColumn(bingoCard, lastCheckedNumberColumn);
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
