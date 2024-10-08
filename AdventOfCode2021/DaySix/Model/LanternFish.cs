namespace DaySix.Model;

public class LanternFish
{
    public int DaysToReproduce { get; set; }

    public LanternFish(int daysToReproduce)
    {
        DaysToReproduce = daysToReproduce;
    }

    public void ResetTimer() => DaysToReproduce = 6;
}
