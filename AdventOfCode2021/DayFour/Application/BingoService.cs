using DayFour.Model;
using DayFour.Validator;

namespace DayFour.Application;

public class BingoService
{
    public List<int> PlayedNumbers { get; set; } = new();

    public int GetDayFourPartOneSolution(BingoCard card)
    {
        return GetUnmarkedNumbers(card).Sum() * PlayedNumbers.Last();
    }

    public List<int> GetUnmarkedNumbers(BingoCard card)
    {
        var unmarkedNumbers = new List<int>();
        foreach (var line in card.Numbers)
        {
            foreach (var number in line)
            {
                if (!PlayedNumbers.Contains(number.Value))
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
        BingoCard winnercard = default!;
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
                PlayedNumbers.Add(number);

                if (isWinnerCard)
                {
                    break;
                }
            }
            break;
        } while (!isWinnerCard);

        return winnercard is null
            ? throw new InvalidDataException("There is no Winning Cards.")
            : winnercard;
    }
}
