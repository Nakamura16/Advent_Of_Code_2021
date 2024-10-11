namespace DaySeven.Extensions;

public static class CollectionExtensions
{
    public static int GetMedian(this List<int> positions)
    {
        var copy = new List<int>(positions);
        copy.Sort();
        return copy[copy.Count / 2];
    }
}
