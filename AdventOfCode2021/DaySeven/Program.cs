using FileReader.Application;

namespace DaySeven;

public class Program
{
    public static void Main(string[] args)
    {
        var filePath = "C:\\Andre\\Estudos\\Advent_Of_Code_2021\\AdventOfCode2021\\DaySeven\\Input.txt";
        var file = new FileReaderTool().ReadFile(filePath).ToList();

        var positions = file[0].Split(",").Select(position => int.Parse(position)).ToList();

        var median = GetMedian(positions);
        var solution = 0;
        foreach (var position in positions)
        {
            var usedFuel = Math.Abs(position - median);
            solution += usedFuel;
        }

        Console.WriteLine($"PartOne Solution: {solution}");
    }

    private static int GetMedian(List<int> positions)
    {
        var copy = new List<int>(positions);
        copy.Sort();
        return copy[copy.Count / 2];
    }
}
