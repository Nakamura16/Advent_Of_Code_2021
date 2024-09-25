using DayFour;
using FileReader.Application;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayFour;

public class EndToEnd
{
    [Fact]
    public void EndToEndTest()
    {
        var fileReader = new FileReaderTool();
        var bingoFormatter = new BingoFormatter();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\Advent_Of_Code_2021\\AdventOfCode2021\\Solutions.Test\\DayFour\\testData.txt";

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

        var sumOfNonCheckedNumbers = new List<int>()
        {
            60, 25, 66, 82, 22,
            94, 45, 68,  5, 12,
            46, 44, 48, 31, 34,
            99, 39, 84, 32,  6,
        };

        solution.Should().Be(sumOfNonCheckedNumbers.Sum() * 81);
    }
}
