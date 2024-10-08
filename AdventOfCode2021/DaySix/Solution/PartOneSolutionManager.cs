using DaySix.Application;
using DaySix.Factory;
using DaySix.Model;

namespace DaySix.Solution;

public class PartOneSolutionManager
{
    private readonly LanternFishFactory factory = new();
    private readonly FishConverter formatter;

    public PartOneSolutionManager()
    {
        formatter = new(factory);
    }

    public int GetSolution(List<string> input, int daysToPass)
    {
        var lanternFish = formatter.ConvertFish(input);
        var lanternFishCopy = new List<LanternFish>(lanternFish);

        for (int pastDays = 0; pastDays < daysToPass; pastDays++)
        {
            ReduceDay(lanternFish);
            for (var i = 0; i < lanternFish.Count; i++)
            {
                var fish = lanternFishCopy[i];
                if (fish.DaysToReproduce == -1)
                {
                    fish.ResetTimer();
                    lanternFishCopy.Add(factory.CreateNewLanternFish());
                }
            }
            lanternFish = lanternFishCopy;
        }
        return lanternFish.Count;
    }

    public void ReduceDay(List<LanternFish> lanterFishes)
    {
        foreach (var fish in lanterFishes)
        {
            fish.DaysToReproduce -= 1;
        }
    }
}
