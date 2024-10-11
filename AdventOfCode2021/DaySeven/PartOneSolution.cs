using DaySeven.Extensions;

namespace DaySeven;

public class PartOneSolution
{
    private readonly InputConverter converter;

    public PartOneSolution(InputConverter converter)
    {
        this.converter = converter;
    }

    public int GetSolution(IList<string> file)
    {
        var positions = converter.Convert(file);
        var median = positions.GetMedian();
        return positions.Select(position => Math.Abs(position - median)).Sum();
    }
}
