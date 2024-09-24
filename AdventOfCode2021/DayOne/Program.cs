using FileReader.Application;

namespace DayOne;

internal class Program
{
    public static void Main(string[] args)
    {
        var fileReader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\DayOne\\Input.txt";

        var depthMeasurements = fileReader
            .ReadFile(filePath)
            .Select(m => int.Parse(m))
            .ToList();

        var solutionForPartOne = new PartOneSolution().Run(depthMeasurements);

        var transformedMeasurements = new PartTwoSolution().TranformMeasurements(depthMeasurements);
        var solutionForPartTwo = new PartOneSolution().Run(transformedMeasurements);

        Console.WriteLine($"Solution for Part One: {solutionForPartOne}");
        Console.WriteLine($"Solution for Part Two: {solutionForPartTwo}");
    }
}