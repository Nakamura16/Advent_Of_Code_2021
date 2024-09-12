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
        });

        var horizontalPosition = 0;
        var depthPosition = 0;

        foreach (var instruction in instructions)
        {
            switch (instruction.direction)
            {
                case "forward":
                    horizontalPosition += instruction.steps; 
                    break;
                case "down":
                    depthPosition += instruction.steps;
                    break;
                case "up":
                    depthPosition -= instruction.steps;
                    break;
            }
        }

        Console.WriteLine($"Solution for Day Two: {horizontalPosition * depthPosition}");
    }
}