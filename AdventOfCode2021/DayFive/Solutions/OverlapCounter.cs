namespace DayFive.Solutions;

public class OverlapCounter
{
    public int CountMoreThanTwoOverlaps(List<List<int>> map)
    {
        var count = 0;
        foreach (var line in map)
        {
            foreach (var item in line)
            {
                if (item > 1)
                {
                    count++;
                }
            }
        }
        return count;
    }
}
