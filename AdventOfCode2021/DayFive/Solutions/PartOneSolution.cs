using DayFive.Model;

namespace DayFive.Solutions;

public class PartOneSolution
{
    public void FillLineSegments(List<LineSegment> segmentsCoordinates, List<List<int>> map)
    {
        foreach (var lineSegment in segmentsCoordinates)
        {
            var isLineSegmentHorizontal = lineSegment.Start.PositionX == lineSegment.End.PositionX;
            var isLineSegmentVertical = lineSegment.Start.PositionY == lineSegment.End.PositionY;

            if (!isLineSegmentHorizontal && !isLineSegmentVertical)
            {
                return;
            }

            if (isLineSegmentHorizontal)
            {
                var startColumn = Math.Min(lineSegment.Start.PositionY, lineSegment.End.PositionY);
                var endColumn = Math.Max(lineSegment.Start.PositionY, lineSegment.End.PositionY);
                for (var actualColumn = startColumn; actualColumn <= endColumn; actualColumn++)
                {
                    map[lineSegment.Start.PositionX][actualColumn]++;
                }
            }
            else if (isLineSegmentVertical)
            {
                var startLine = Math.Min(lineSegment.Start.PositionX, lineSegment.End.PositionX);
                var endLine = Math.Max(lineSegment.Start.PositionX, lineSegment.End.PositionX);
                for (var actualLine = startLine; actualLine <= endLine; actualLine++)
                {
                    map[actualLine][lineSegment.Start.PositionY]++;
                }
            }
        }
    }
}
