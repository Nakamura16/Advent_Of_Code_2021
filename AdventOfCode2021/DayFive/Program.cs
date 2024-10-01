using DayFive.Application;
using DayFive.Converter;
using DayFive.Helper;
using DayFive.Solutions;
using FileReader.Application;

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
        var lineSegmentMarker = new LineSegmentMarker();
        var overlapCounter = new OverlapCounter();

        var lineSegments = converter.Convert(file);
        var map = MatrixCreator.CreateMatrix(matrixSize);
        lineSegmentMarker.MarkHorizontalAndVerticalLineSegments(lineSegments, map);

        var partOneResult = overlapCounter.CountMoreThanTwoOverlaps(map);
        Console.WriteLine($"Solution for PartOne: {partOneResult}");

        var mapPartTwo = MatrixCreator.CreateMatrix(matrixSize);
        lineSegmentMarker.MarkAllLineSegments(lineSegments, mapPartTwo);

        var partTwoResult = overlapCounter.CountMoreThanTwoOverlaps(mapPartTwo);
        Console.WriteLine($"Solution for PartTwo: {partTwoResult}");
    }
}