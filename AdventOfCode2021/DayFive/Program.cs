using DayFive.Converter;
using DayFive.Helper;
using DayFive.Solutions;
using FileReader.Application;
using System.Runtime.CompilerServices;

namespace DayFive;

public class Program
{
    private const int matrixSize = 1000;

    public static void Main(string[] args)
    {
        var fileReader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\DayFive\\Input.txt";
        var file = fileReader.ReadFile(filePath).ToList();

        var converter = new LineSegmentConverter();
        var partOne = new PartOneSolution();

        var lineSegments = converter.Convert(file);
        var map = MatrixCreator.CreateMatrix(matrixSize);
        partOne.MarkAllLineSegments(lineSegments, map);

        var partOneResult = partOne.VerifyResult(map);
        Console.WriteLine($"Solution for PartOne: {partOneResult}");
    }
}