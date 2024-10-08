using DaySix.Factory;
using DaySix.Model;

namespace DaySix.Application;

public class FishConverter
{
    private readonly LanternFishFactory factory;

    public FishConverter(LanternFishFactory factory)
    {
        this.factory = factory;
    }

    public List<LanternFish> ConvertFish(List<string> input)
    {
        var existingFishDays = input.Single().Split(',').ToList();
        return existingFishDays
            .Select(day => factory.CreateExistingLanternFish(int.Parse(day)))
            .ToList();
    }
}
