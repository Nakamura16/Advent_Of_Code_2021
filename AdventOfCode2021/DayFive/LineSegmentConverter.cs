using DayFive.Model;
namespace DayFive;

public class LineSegmentConverter
{
    public List<LineSegment> Convert(IList<string> inputLines)
    {
        return inputLines.Select(line =>
        {
            var cordinates = line.Split(" -> ");
            var startCordinate = cordinates[0].Split(",");
            var endCordinate = cordinates[1].Split(",");

            return new LineSegment(
                Start: new Cordinate(startCordinate[0], startCordinate[1]),
                End: new Cordinate(endCordinate[0], endCordinate[1]));
        }).ToList();
    }
}
