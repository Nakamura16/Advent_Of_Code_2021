using DayFive.Application.Impl;
using DayFive.Converter;
using DayFive.Solution;
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
        var solutionManager = new SolutionManager(converter, lineSegmentMarker, overlapCounter);

        Console.WriteLine($"Solution for PartOne: {solutionManager.GetPartOneSolution(file, matrixSize)}");
        Console.WriteLine($"Solution for PartTwo: {solutionManager.GetPartTwoSolution(file, matrixSize)}");
    }
}