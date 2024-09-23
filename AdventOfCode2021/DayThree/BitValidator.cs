namespace DayThree;

public class BitValidator
{
    public int ZerosQuantity { get; set; }
    public int OnesQuantity { get; set; }

    public void CheckNumber(double currentBit)
    {
        if (currentBit == 0)
        {
            ZerosQuantity ++;
        }
        else if (currentBit == 1)
        {
            OnesQuantity ++;
        }
    }

    public string ValidateQuantityOfNumbers()
    {
        if (ZerosQuantity > OnesQuantity)
        {
            ResetNumbers();
            return "0";
        }
        else if (OnesQuantity > ZerosQuantity)
        {
            ResetNumbers();
            return "1";
        }
        else 
        {
            throw new ArgumentException(
                $"The {nameof(OnesQuantity)} and {nameof(ZerosQuantity)} are the same: "
                + $"\n\nNumbersOnesQuantity:{OnesQuantity} "
                + $"\nNumbersZeroQuantity:{ZerosQuantity}");
        }
    }

    private void ResetNumbers()
    {
        ZerosQuantity = 0;
        OnesQuantity = 0;
    }
}
