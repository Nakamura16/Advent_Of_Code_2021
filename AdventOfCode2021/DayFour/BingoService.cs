namespace DayFour;

public class BingoService
{
    public List<int> playedNumbers = new();

    public int GetDayFourPartOneSolution(BingoCard card)
    {
        var lastNumber = playedNumbers.Last() == 0 ? playedNumbers[playedNumbers.Count - 2] : playedNumbers.Last();
        var sumOfUnmarkedNumbers = GetSumOfUnmarkedNumbers(card);
        return sumOfUnmarkedNumbers * lastNumber;
    }

    public int GetSumOfUnmarkedNumbers(BingoCard card)
    {
        var unmarkedNumbers = GetUnmarkedNumbers(card);
        return unmarkedNumbers.Sum();
    }

    public List<int> GetUnmarkedNumbers(BingoCard card)
    {
        var unmarkedNumbers = new List<int>();
        foreach(var line in card.Numbers)
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
                        break;
                    };
                }
                playedNumbers.Add(number);
                if (isWinnerCard)
                {
                    break;
                }
            }
        } while (!isWinnerCard);
        return winnercard;
    }
}
