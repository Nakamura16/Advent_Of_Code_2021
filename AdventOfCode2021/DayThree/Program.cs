﻿using DayThree;
using FileReader.Application;

internal class Program
{
    public static void Main(string[] args)
    {
        var reader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\DayThree\\Input.txt";

        var bytes = reader.ReadFile(filePath).ToList();

        var partOneResult = new PartOne().Execute(bytes);
        
        Console.WriteLine($"Solution for Part One: {partOneResult}");
    }
}