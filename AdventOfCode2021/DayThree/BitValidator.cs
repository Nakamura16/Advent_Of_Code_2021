namespace DayThree;

class BitValidator
{
    private int NumbersZeroQuantity { get; set; }
    private int NumbersOnesQuantity { get; set; }

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
        else
        {
            ResetNumbers();
            return "1";
        }
    }

    private void ResetNumbers()
    {
        NumbersZeroQuantity = 0;
        NumbersOnesQuantity = 0;
    }
}
