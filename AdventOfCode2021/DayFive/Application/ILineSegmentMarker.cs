using DayFive.Model;

namespace DayFive.Application;
public interface ILineSegmentMarker
{
    DiagonalDirections GetDiagonalDirection(LineSegment lineSegment);
    void MarkAllLineSegments(List<LineSegment> segmentsCoordinates, List<List<int>> map);
    void MarkDiagonalLineSegment(List<List<int>> map, LineSegment lineSegment);
    void MarkHorizontalAndVerticalLineSegments(List<LineSegment> segmentsCoordinates, List<List<int>> map);
}