using DaySeven.Extensions;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DaySeven;

public class CollectionExtensionTests
{
    [Theory]
    [MemberData(nameof(GetListOfIntergers))]
    public void GetMedian_WithListOfIntergers_ShouldReturnCorrectMedian(
        List<int> numbers,
        int expectedMedian)
    {
        var result = numbers.GetMedian();

        result.Should().Be(expectedMedian);
    }

    public static TheoryData<List<int>, int> GetListOfIntergers()
    {
        return new TheoryData<List<int>, int>()
        {
            { new() {1, 2, 3, 4}, 3 },
            { new() {1, 5, 3, 4}, 4 },
            { new() {2, 2, 3, 4}, 3 },
            { new() {4, 6, 7, 8}, 7 },
        };
    }
}
