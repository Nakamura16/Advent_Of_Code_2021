namespace DayFour;

public class BingoFormatter
{
    public List<BingoCard> FormatBingoCards(IList<string> inputFile)
    {
        var bingoCards = new List<BingoCard>();
        var bingoCard = new List<List<int>>();
        foreach (var line in inputFile)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                var numbers = line.Split(" ")
                    .Where(number => !string.IsNullOrWhiteSpace(number))
                    .Select(number => int.Parse(number)).ToList();
                bingoCard.Add(numbers);

            }
            if(bingoCard.Count == 5)
            {
                bingoCards.Add(new BingoCard(new List<List<int>>(bingoCard)));
                bingoCard.Clear();
            }
        }
        return bingoCards;
    }
}
