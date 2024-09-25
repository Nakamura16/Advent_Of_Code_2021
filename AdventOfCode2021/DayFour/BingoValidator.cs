namespace DayFour;

public class BingoValidator
{
    private const int bingoCardSize = 5;

    public void VerifyBingoCards(int number, List<BingoCard> cards)
    {
        foreach (var bingoCard in cards)
        {
            for (int line = 0; line < bingoCard.numbers.Count; line++)
            {
                for (int column = 0; column < bingoCard.numbers[line].Count; column++)
                {
                    if (bingoCard.numbers[line][column].Value == number)
                    {
                        bingoCard.numbers[line][column].IsChecked = true;
                        VerifyLine(bingoCard.numbers[line]);
                        VerifyColumn(bingoCard.numbers, column);
                    }
                }
            }
        }
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
