using FileReader.Application;

namespace DaySeven;

public class Program
{
    public static void Main(string[] args)
    {
        var filePath = "C:\\Andre\\Estudos\\Advent_Of_Code_2021\\AdventOfCode2021\\DaySeven\\Input.txt";
        var file = new FileReaderTool().ReadFile(filePath).ToList();

        Console.WriteLine($"PartOne Solution: {new PartOneSolution(new InputConverter()).GetSolution(file)}");
        Console.WriteLine($"PartTwo Solution: {new PartTwoSolution(new InputConverter()).GetSolution(file)}");
    }
}
