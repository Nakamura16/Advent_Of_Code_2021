namespace DayThree;

public class BitValidator
{
    public int NumbersZeroQuantity { get; set; }
    public int NumbersOnesQuantity { get; set; }

    public void ValidateNumber(double currentBit)
    {
        if (currentBit == 0)
        {
            NumbersZeroQuantity++;
        }
        else if (currentBit == 1)
        {
            NumbersOnesQuantity++;
        }
    }

    public string ValidateQuantityOfNumbers()
    {
        if (NumbersZeroQuantity > NumbersOnesQuantity)
        {
            ResetNumbers();
            return "0";
        }
        else if (NumbersOnesQuantity > NumbersZeroQuantity)
        {
            ResetNumbers();
            return "1";
        }
        else 
        {
            throw new ArgumentException(
                $"The {nameof(NumbersOnesQuantity)} and {nameof(NumbersZeroQuantity)} are the same: "
                + $"\n\nNumbersOnesQuantity:{NumbersOnesQuantity} "
                + $"\nNumbersZeroQuantity:{NumbersZeroQuantity}");
        }
    }

    private void ResetNumbers()
    {
        NumbersZeroQuantity = 0;
        NumbersOnesQuantity = 0;
    }
}
