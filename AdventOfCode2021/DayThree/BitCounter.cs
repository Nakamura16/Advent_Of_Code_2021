namespace DayThree;

public class BitCounter
{
    public int ZerosQuantity { get; set; }
    public int OnesQuantity { get; set; }

    public void CountBit(double currentBit)
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

    public string GetMostCommonBit()
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
            ResetNumbers();
            return "1";
        }
    }

    private void ResetNumbers()
    {
        ZerosQuantity = 0;
        OnesQuantity = 0;
    }
}
