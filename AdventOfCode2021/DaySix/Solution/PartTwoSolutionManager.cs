using DaySix.Application;
using DaySix.Factory;
using DaySix.Model;

namespace DaySix.Solution;

public class PartTwoSolutionManager
{
    private readonly LanternFishFactory factory = new();
    private readonly FishConverter formatter;

    public PartTwoSolutionManager()
    {
        formatter = new(factory);
    }

    public long GetSolution(List<string> input, int daysToPass)
    {
        var lanternFishes = formatter.ConvertFish(input);

        var fishCounter = new long[9];
        InitializeCounter(lanternFishes, fishCounter);

        for (int pastDays = 0; pastDays < daysToPass; pastDays++)
        {
            var fishGoingReproduce = fishCounter[0];

            ReduceDay(fishCounter);
            fishCounter[6] += fishGoingReproduce;
            fishCounter[8] = fishGoingReproduce;
        }
        return fishCounter.Sum();
    }

    // TODO: Add tests
    public void ReduceDay(long[] counter)
    {
        for (int i = 1; i <= 8; i++)
        {
            counter[i - 1] = counter[i];
        }
    }

    // TODO: Add tests
    public void InitializeCounter(List<LanternFish> lanternFishes, long[] counter)
    {
        foreach (var fish in lanternFishes)
        {
            counter[fish.DaysToReproduce]++;
        }
    }
}
