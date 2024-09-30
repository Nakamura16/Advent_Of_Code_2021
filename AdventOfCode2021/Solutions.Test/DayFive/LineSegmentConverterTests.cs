using DayFive.Converter;
using DayFive.Model;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayFive;

public class LineSegmentConverterTests
{
    private readonly LineSegmentConverter converter = new();

    [Fact]
    public void Convert_WithCorrectInputData_ShouldConvertCorrectly()
    {
        var inputData = new List<string>()
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1" 
        };

        var result = converter.Convert(inputData);

        var expectedResult = new List<LineSegment>()
        {
            new(new(0,9), new(5,9)),
            new(new(8,0), new(0,8)),
            new(new(9,4), new(3,4)),
            new(new(2,2), new(2,1))
        };
        result.Should().BeEquivalentTo(expectedResult);
    }
}
