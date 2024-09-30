using DayTwo;
using FileReader.Application;

internal class Program
{
    public static void Main(string[] args)
    {
        var reader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\DayTwo\\input.txt";

        var instructions = new InstructionsFormatter().GetInstructions(reader.ReadFile(filePath));

        var partOneSolution = new PartOne().Calculate(instructions);
        Console.WriteLine($"Solution for Part one: {partOneSolution}");

        var partTwoSolution = new PartTwo().Calculate(instructions);
        Console.WriteLine($"Solution for Part Two: {partTwoSolution}");
    }
}