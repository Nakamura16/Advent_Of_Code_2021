using DayFour.Model;

namespace DayFour.Application.Impl;

public class BingoFormatter : IBingoFormatter
{
    private const int BingoCardSize = 5;

    public List<BingoCard> FormatBingoCards(IList<string> inputFile)
    {
        RemoveNumbersLine(inputFile);

        var bingoCards = new List<BingoCard>();
        var cardNumbers = new List<List<Number>>();
        foreach (var line in inputFile)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                var numbers = line.Split(" ")
                    .Where(number => !string.IsNullOrWhiteSpace(number))
                    .Select(number => new Number(int.Parse(number)))
                    .ToList();
                cardNumbers.Add(numbers);
            }
            if (cardNumbers.Count == BingoCardSize)
            {
                bingoCards.Add(new BingoCard(new(cardNumbers)));
                cardNumbers.Clear();
            }
        }
        return bingoCards;
    }

    private static void RemoveNumbersLine(IList<string> file)
    {
        file.RemoveAt(0);
    }

    // TODO: test GetBingoNumbers
    public List<int> GetBingoNumbers(IList<string> file)
    {
        return file
            .Single(line => line.Length > 15)
            .Split(",")
            .Select(number => int.Parse(number))
            .ToList();
    }
}
