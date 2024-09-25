namespace DayTwo;

public class PartTwo
{
    public int Calculate(IReadOnlyList<(string direction, int steps)> instructions)
    {
        var horizontalPosition = 0;
        var depthPosition = 0;
        var aim = 0;
        foreach (var (direction, units) in instructions)
        {
            switch (direction)
            {
                case "forward":
                    horizontalPosition += units;
                    depthPosition += aim * units;
                    break;
                case "down":
                    aim += units;
                    break;
                case "up":
                    aim -= units;
                    break;
            }
        }
        return horizontalPosition * depthPosition;
    }
}
