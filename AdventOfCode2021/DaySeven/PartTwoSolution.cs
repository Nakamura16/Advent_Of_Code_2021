namespace DaySeven;

public class PartTwoSolution
{
    private readonly InputConverter converter;

    public PartTwoSolution(InputConverter converter)
    {
        this.converter = converter;
    }

    public int GetSolution(IList<string> file)
    {
        var positions = converter.Convert(file);

        int minCost = int.MaxValue; //2147483647
        for (int target = positions.Min(); target <= positions.Max(); target++)
        {
            int cost = CalculateFuelCost(target, positions);
            if (cost < minCost)
            {
                minCost = cost;
            }
        }
        return minCost;
    }

    private int CalculateFuelCost(int target, IList<int> positions)
    {
        return positions.Sum(pos =>
        {
            int distance = Math.Abs(pos - target);
            return (distance * (distance + 1)) / 2;
        });
    }
}
