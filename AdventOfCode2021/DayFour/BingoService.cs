namespace DayFour;

public class BingoService
{
    public readonly List<int> playedNumbers = new();

    public int GetSumOfUnmarkedNumbers(BingoCard card)
    {
        var unmarkedNumbers = GetUnmarkedNumbers(card);
        int sum = default;
        foreach (var line in unmarkedNumbers)
        {
            foreach (var number in line)
            {
                sum += number;
            }
        }
        return sum;
    }

    public List<List<int>> GetUnmarkedNumbers(BingoCard card)
    {
        return card.numbers.Select(line =>
        {
            return line
                .Where(number => !playedNumbers.Contains(number.Value))
                .Select(number => number.Value)
                .ToList();
        }).ToList();
    }

    public BingoCard GetWinningBingoCard(List<int> numbers, List<BingoCard> cards)
    {
        var isWinnerCard = false;
        BingoCard winnercard = default;
        var validator = new BingoValidator();
        do
        {
            foreach (var number in numbers)
            {
                foreach (var card in cards)
                {
                    if (validator.IsWinnerCard(number, card))
                    {
                        isWinnerCard = true;
                        winnercard = card;
                    };
                }
                playedNumbers.Add(number);
            }
        } while (!isWinnerCard);
        return winnercard;
    }
}
