using DayTwo;
using FileReader.Application;

internal class Program
{
    public static void Main(string[] args)
    {
        var reader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\DayTwo\\input.txt";

        var instructions = reader.ReadFile(filePath).Select(instruction =>
        {
            var instructionWords = instruction.Split(" ");
            var direction = instructionWords[0];
            var steps = int.Parse(instructionWords[1]);
            return (direction, steps);
        }).ToList();

        var partOneSolution = new PartOne().Calculate(instructions);

        Console.WriteLine($"Solution for Day Two: {partOneSolution}");
    }
}