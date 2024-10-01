using DayFive.Converter.Impl;
using DayFive.Model;
namespace DayFive.Converter;

public class LineSegmentConverter : ILineSegmentConverter
{
    public List<LineSegment> Convert(IList<string> inputLines)
    {
        return inputLines.Select(line =>
        {
            var cordinates = line.Split(" -> ");
            var startCordinate = cordinates[0].Split(",");
            var endCordinate = cordinates[1].Split(",");

            return new LineSegment(
                start: new Coordinate(int.Parse(startCordinate[0]), int.Parse(startCordinate[1])),
                end: new Coordinate(int.Parse(endCordinate[0]), int.Parse(endCordinate[1])));
        }).ToList();
    }
}
