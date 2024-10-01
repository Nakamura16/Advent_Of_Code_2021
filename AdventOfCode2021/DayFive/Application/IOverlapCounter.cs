namespace DayFive.Application;

public interface IOverlapCounter
{
    int CountMoreThanTwoOverlaps(List<List<int>> map);
}