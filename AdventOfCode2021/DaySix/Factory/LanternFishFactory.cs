using DaySix.Model;

namespace DaySix.Factory;

public class LanternFishFactory
{
    public LanternFish CreateNewLanternFish()
    {
        return new LanternFish(8);
    }

    public LanternFish CreateExistingLanternFish(int daysToReproduce)
    {
        return new LanternFish(daysToReproduce);
    }
}
