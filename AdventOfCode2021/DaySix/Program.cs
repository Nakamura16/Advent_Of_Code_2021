using DaySix.Solution;
using FileReader.Application;

namespace DaySix;

public class Program
{
    public static void Main(string[] args)
    {
        var filePath = "C:\\Andre\\Estudos\\Advent_Of_Code_2021\\"
            + "AdventOfCode2021\\DaySix\\Input.txt";
        var file = new FileReaderTool().ReadFile(filePath).ToList();

        var partOneSolution = new PartOneSolutionManager().GetSolution(file, 80);
        Console.WriteLine($"Part One Solution: {partOneSolution}");

        var partTwoSolution = new PartTwoSolutionManager().GetSolution(file, 256);
        Console.WriteLine($"Part Two Solution: {partTwoSolution}");
    }
}
