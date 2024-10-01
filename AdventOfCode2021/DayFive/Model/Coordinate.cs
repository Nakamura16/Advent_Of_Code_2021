namespace DayFive.Model;

public class Coordinate
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    public Coordinate(int positionX, int positionY)
    {
        PositionX = positionX;
        PositionY = positionY;
    }

    public bool Equals(Coordinate coordinate)
    {
        return PositionX == coordinate.PositionX && PositionY == coordinate.PositionY;
    }
}
