using DayFive.Solutions;
using FileReader.Application;

namespace DayFive;

public class Program
{
    public static void Main(string[] args)
    {
        var fileReader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\DayFive\\Input.txt";
        var file = fileReader.ReadFile(filePath).ToList();

        var converter = new LineSegmentConverter();
        var convertedInput = converter.Convert(file);

        var partOne = new PartOneSolution();
        var map = CreateMatrix();
        partOne.FillLineSegments(convertedInput, map);
        var partOneResult = partOne.VerifyResult(map);

        Console.WriteLine($"Solution for PartOne: {partOneResult}");
    }

    public static List<List<int>> CreateMatrix()
    {
        var line = new List<int>();
        var matrix = new List<List<int>>();
        for (int i = 0; i < 1000; i++)
        {
            line.Add(0);
        }

        for (int i = 0; i < 1000; i++)
        {
            matrix.Add(new(line));
        }
        return matrix;
    }
}