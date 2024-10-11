using DaySeven;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DaySeven;

public class InputConverterTests
{
    private readonly InputConverter converter = new();

    [Fact]
    public void Convert_WithStandardInput_ShouldConvertCorrectly()
    {
        var standardInput = new List<string> { "1,2,3,4,5" };

        var result = converter.Convert(standardInput);

        var expected = new List<int> { 1, 2, 3, 4, 5 };
        result.Should().BeEquivalentTo(expected);
    }
}
