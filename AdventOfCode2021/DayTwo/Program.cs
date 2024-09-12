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
        Console.WriteLine($"Solution for Day Two: {horizontalPosition * depthPosition}");

        //var partOneSolution = new PartOne().Calculate(instructions);
        //Console.WriteLine($"Solution for Day Two: {partOneSolution}");
    }
}