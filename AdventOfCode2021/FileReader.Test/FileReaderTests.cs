using FileReader.Application;
using FluentAssertions;
using Xunit;

namespace FileReader.Test;

public class FileReaderTests
{
    private readonly FileReaderTool reader = new FileReaderTool();

    [Fact]
    public void ReadFile_WithExistingFullFilledTextFile_ShouldReadLineByLineCorrectly()
    {
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\FileReader.Test\\TestFile.txt";

        var result = reader.ReadFile(filePath);

        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
        result.Count.Should().Be(7);
        var expectedResult = File.ReadLines(filePath);
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void ReadFile_WithExistingEmptyTextFile_ShouldThrowException()
    {
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\FileReader.Test\\TestEmptyFile.txt";

        reader.Invoking(r => r.ReadFile(filePath))
            .Should()
            .ThrowExactly<Exception>()
            .WithMessage("The current file is empty.");
    }
}
