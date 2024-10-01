using DayFive.Model;

namespace DayFive.Converter.Impl;
public interface ILineSegmentConverter
{
    List<LineSegment> Convert(IList<string> inputLines);
}