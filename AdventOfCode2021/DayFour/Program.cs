using DayFour.Application.Impl;
using DayFour.Solutions;
using DayFour.Validator;
using DayFour.Validator.Impl;
using FileReader.Application;

namespace DayFour;

internal class Program
{
    public static void Main(string[] args)
    {
        var fileReader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\Advent_Of_Code_2021\\"
            + "AdventOfCode2021\\DayFour\\Input.txt";
        var file = fileReader.ReadFile(filePath).ToList();

        var formatter = new BingoFormatter();
        var validator = new BingoValidator();
        var service = new BingoService(validator);
        var partOneSolution = new PartOneSolution(formatter, service).ExecuteSolution(file);
        Console.WriteLine($"Solution PartOne: {partOneSolution}");
    }
}