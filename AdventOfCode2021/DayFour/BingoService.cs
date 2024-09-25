namespace DayFour;

public class BingoService
{
    public List<int> playedNumbers = new();

    public int GetDayFourPartOneSolution(BingoCard card)
    {
        return GetSumOfUnmarkedNumbers(card) * playedNumbers.Last();
    }

    public int GetSumOfUnmarkedNumbers(BingoCard card)
    {
        var unmarkedNumbers = GetUnmarkedNumbers(card);
        return unmarkedNumbers.Sum();
    }

    public List<int> GetUnmarkedNumbers(BingoCard card)
    {
        var unmarkedNumbers = new List<int>();
        foreach(var line in card.numbers)
        {
            foreach (var number in line)
            {
                if (!playedNumbers.Contains(number.Value))
                {
                    unmarkedNumbers.Add(number.Value);
                }
            }
        }
        return unmarkedNumbers;
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
