namespace DayFive.Model;

public class LineSegment
{
    public Coordinate Start { get; set; }
    public Coordinate End { get; set; }
    public DiagonalDirections? Direction { get; set; }

    public LineSegment(Coordinate start, Coordinate end, DiagonalDirections? direction = null)
    {
        Start = start;
        End = end;
        Direction = direction;
    }
}
