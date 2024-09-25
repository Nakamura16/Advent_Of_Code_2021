﻿using FileReader.Application;

namespace DayFour;

internal class Program
{
    public static void Main(string[] args)
    {
        var fileReader = new FileReaderTool();
        var bingoFormatter = new BingoFormatter();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\Advent_Of_Code_2021\\"
            + "AdventOfCode2021\\DayFour\\Input.txt";

        var file = fileReader.ReadFile(filePath).ToList();
        var bingoNumbers = file
            .Single(line => line.Length > 15)
            .Split(",")
            .Select(number => int.Parse(number))
            .ToList();

        file.RemoveAt(0);
        var bingoCards = bingoFormatter.FormatBingoCards(file);

        var service = new BingoService();
        var winningCard = service.GetWinningBingoCard(bingoNumbers, bingoCards);
        var solution = service.GetDayFourPartOneSolution(winningCard);

        Console.WriteLine($"Solution PartOne: {solution}");
    }
}