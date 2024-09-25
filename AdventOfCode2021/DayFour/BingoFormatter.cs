namespace DayFour;

public class BingoFormatter
{
    private const int BingoCardSize = 5;

    public List<BingoCard> FormatBingoCards(IList<string> inputFile)
    {
        RemoveNumbersLine(inputFile);

        var bingoCards = new List<BingoCard>();
        var bingoCardNumbers = new List<List<Number>>();
        foreach (var line in inputFile)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                var numbers = line.Split(" ")
                    .Where(number => !string.IsNullOrWhiteSpace(number))
                    .Select(number => new Number(int.Parse(number)))
                    .ToList();
                bingoCardNumbers.Add(numbers);
            }
            if(bingoCardNumbers.Count == BingoCardSize)
            {
                bingoCards.Add(new BingoCard(new(bingoCardNumbers)));
                bingoCardNumbers.Clear();
            }
        }
        return bingoCards;
    }

    private void RemoveNumbersLine(IList<string> file)
    {
        file.RemoveAt(0);
    }
}
