using DayFour.Application.Impl;
using DayFour.Solutions;
using DayFour.Validator.Impl;
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
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\Solutions.Test\\DayFour\\testData.txt";
        var file = fileReader.ReadFile(filePath).ToList();

        var formatter = new BingoFormatter();
        var validator = new BingoValidator();
        var service = new BingoService(validator);
        var result = new PartOneSolution(formatter, service).ExecuteSolution(file);

        var sumOfNonCheckedNumbers = new List<int>()
        {
            60, 25, 66, 82, 22,
            94, 45, 68,  5, 12,
            46, 44, 48, 31, 34,
            99, 39, 84, 32,  6,
        };
        result.Should().Be(sumOfNonCheckedNumbers.Sum() * 81);
    }
}
