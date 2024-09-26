using DayFour.Model;
using DayFour.Validator;
using DayFour.Validator.Impl;

namespace DayFour.Application.Impl;

public class BingoService : IBingoService
{
    public IList<int> PlayedNumbers { get; set; } = new List<int>();

    private readonly IBingoValidator validator;

    public BingoService(IBingoValidator bingoValidator)
    {
        validator = bingoValidator;
    }

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

    public BingoCard GetWinningBingoCard(IList<int> numbersToPlay, IList<BingoCard> cards)
    {
        var isWinnerCard = false;
        BingoCard winnercard = default!;
        do
        {
            foreach (var number in numbersToPlay)
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

        return validator.IsWinnerCardValid(winnercard) 
            ? winnercard
            : throw new InvalidDataException("There is no Winning Cards.");
    }

    public BingoCard GetLastWinningBingoCard(IList<int> numbers, IList<BingoCard> cards)
    {
        var winningCards = new List<BingoCard>();
        do
        {
            foreach (var number in numbers)
            {
                foreach (var card in cards)
                {
                    if (validator.IsWinnerCard(number, card))
                    {
                        winningCards.Add(card);
                        break;
                    };
                }
                PlayedNumbers.Add(number);

                if (winningCards.Count != cards.Count)
                {
                    break;
                }
            }
            break;
        } while (winningCards.Count != cards.Count);

        return winningCards.Last();
    }

    IList<int> IBingoService.GetUnmarkedNumbers(BingoCard card)
    {
        throw new NotImplementedException();
    }
}
