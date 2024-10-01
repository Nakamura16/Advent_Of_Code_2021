using DayFive.Model;

namespace DayFive.Application.Impl;

public class LineSegmentMarker : ILineSegmentMarker
{
    public void MarkHorizontalAndVerticalLineSegments(List<LineSegment> segmentsCoordinates, List<List<int>> map)
    {
        foreach (var lineSegment in segmentsCoordinates)
        {
            var isLineSegmentHorizontal = lineSegment.Start.PositionX == lineSegment.End.PositionX;
            var isLineSegmentVertical = lineSegment.Start.PositionY == lineSegment.End.PositionY;

            if (isLineSegmentHorizontal)
            {
                MarkHorizontalLineSegment(map, lineSegment);
            }
            else if (isLineSegmentVertical)
            {
                MarkVerticalLineSegment(map, lineSegment);
            }
        }
    }

    // TODO: Add tests
    public void MarkAllLineSegments(List<LineSegment> segmentsCoordinates, List<List<int>> map)
    {
        foreach (var lineSegment in segmentsCoordinates)
        {
            var isLineSegmentHorizontal = lineSegment.Start.PositionX == lineSegment.End.PositionX;
            var isLineSegmentVertical = lineSegment.Start.PositionY == lineSegment.End.PositionY;

            if (isLineSegmentHorizontal)
            {
                MarkHorizontalLineSegment(map, lineSegment);
            }
            else if (isLineSegmentVertical)
            {
                MarkVerticalLineSegment(map, lineSegment);
            }
            else
            {
                MarkDiagonalLineSegment(map, lineSegment);
            }
        }
    }

    public void MarkDiagonalLineSegment(List<List<int>> map, LineSegment lineSegment)
    {
        lineSegment.Direction = GetLineSegmentPosition(lineSegment);
        var currentPoint = new Coordinate(lineSegment.Start.PositionX, lineSegment.Start.PositionY);

        while (!currentPoint.Equals(lineSegment.End))
        {
            // TODO: try to not use switch case
            switch (lineSegment.Direction)
            {
                case DiagonalDirections.UpRight:
                    map[currentPoint.PositionX][currentPoint.PositionY]++;
                    currentPoint.PositionX--;
                    currentPoint.PositionY++;
                    break;
                case DiagonalDirections.UpLeft:
                    map[currentPoint.PositionX][currentPoint.PositionY]++;
                    currentPoint.PositionX--;
                    currentPoint.PositionY--;
                    break;
                case DiagonalDirections.DownRight:
                    map[currentPoint.PositionX][currentPoint.PositionY]++;
                    currentPoint.PositionX++;
                    currentPoint.PositionY++;
                    break;
                case DiagonalDirections.DownLeft:
                    map[currentPoint.PositionX][currentPoint.PositionY]++;
                    currentPoint.PositionX++;
                    currentPoint.PositionY--;
                    break;
            }

            if (currentPoint.Equals(lineSegment.End))
            {
                map[currentPoint.PositionX][currentPoint.PositionY]++;
            }
        }
    }

    // This method is a mess, how can I imporve this?
    public DiagonalDirections GetLineSegmentPosition(LineSegment lineSegment)
    {
        var isLineSegmentHorizontal = lineSegment.Start.PositionX == lineSegment.End.PositionX;
        var isLineSegmentVertical = lineSegment.Start.PositionY == lineSegment.End.PositionY;
        var isFinalPositionXBiggerThanStart = lineSegment.End.PositionX > lineSegment.Start.PositionX;
        var isFinalPositionYBiggerThanStart = lineSegment.End.PositionY > lineSegment.Start.PositionY;

        if (isLineSegmentHorizontal)
        {
            return DiagonalDirections.Horizontal;
        }
        else if (isLineSegmentVertical) 
        {
            return DiagonalDirections.Vertical;
        }
        else if (!isFinalPositionXBiggerThanStart && isFinalPositionYBiggerThanStart)
        {
            return DiagonalDirections.UpRight;
        }
        else if (!isFinalPositionXBiggerThanStart && !isFinalPositionYBiggerThanStart)
        {
            return DiagonalDirections.UpLeft;
        }
        else if (isFinalPositionXBiggerThanStart && isFinalPositionYBiggerThanStart)
        {
            return DiagonalDirections.DownRight;
        }
        else if (isFinalPositionXBiggerThanStart && !isFinalPositionYBiggerThanStart)
        {
            return DiagonalDirections.DownLeft;
        }
        return default;
    }

    // Add tests for both of this private methods
    private void MarkVerticalLineSegment(List<List<int>> map, LineSegment lineSegment)
    {
        var startLine = Math.Min(lineSegment.Start.PositionX, lineSegment.End.PositionX);
        var endLine = Math.Max(lineSegment.Start.PositionX, lineSegment.End.PositionX);
        for (var actualLine = startLine; actualLine <= endLine; actualLine++)
        {
            map[actualLine][lineSegment.Start.PositionY]++;
        }
    }

    private void MarkHorizontalLineSegment(List<List<int>> map, LineSegment lineSegment)
    {
        var startColumn = Math.Min(lineSegment.Start.PositionY, lineSegment.End.PositionY);
        var endColumn = Math.Max(lineSegment.Start.PositionY, lineSegment.End.PositionY);
        for (var actualColumn = startColumn; actualColumn <= endColumn; actualColumn++)
        {
            map[lineSegment.Start.PositionX][actualColumn]++;
        }
    }
}
