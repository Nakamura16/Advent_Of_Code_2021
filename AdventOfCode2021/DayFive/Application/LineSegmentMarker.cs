using DayFive.Model;

namespace DayFive.Application;

public class LineSegmentMarker
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
        lineSegment.Direction = GetDiagonalDirection(lineSegment);
        var currentPoint = new Coordinate(lineSegment.Start.PositionX, lineSegment.Start.PositionY);

        while (!currentPoint.Equals(lineSegment.End)) 
        {
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

    public DiagonalDirections GetDiagonalDirection(LineSegment lineSegment)
    {
        var isDiagonalUpRight = lineSegment.End.PositionX < lineSegment.Start.PositionX
            && lineSegment.End.PositionY > lineSegment.Start.PositionY;
        var isDiagonalDownRight = lineSegment.End.PositionX > lineSegment.Start.PositionX
            && lineSegment.End.PositionY > lineSegment.Start.PositionY;
        var isDiagonalDownLeft = lineSegment.End.PositionX > lineSegment.Start.PositionX
            && lineSegment.End.PositionY < lineSegment.Start.PositionY;
        var isDiagonalUpLeft = lineSegment.End.PositionX < lineSegment.Start.PositionX
            && lineSegment.End.PositionY < lineSegment.Start.PositionY;

        if (isDiagonalUpRight)
        {
            return DiagonalDirections.UpRight;
        }
        else if (isDiagonalUpLeft)
        {
            return DiagonalDirections.UpLeft;
        }
        else if(isDiagonalDownRight)
        {
            return DiagonalDirections.DownRight;
        }
        else if(isDiagonalDownLeft)
        {
            return DiagonalDirections.DownLeft;
        }

        throw new ArgumentException("There is no valid Direction.");
    }

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
