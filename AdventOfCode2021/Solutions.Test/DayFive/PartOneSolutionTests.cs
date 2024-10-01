using DayFive.Model;
using DayFive.Solutions;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayFive;

public class PartOneSolutionTests
{
    private readonly OverlapCounter solution = new();

    [Fact]
    public void VerifyResult_ShoulReturnTheCorrectAmountOfNumbers()
    {
        var map = new List<List<int>>()
        {
            new(){ 0, 0, 0, 2, 0},
            new(){ 0, 0, 0, 1, 0},
            new(){ 0, 2, 0, 0, 0},
            new(){ 0, 0, 0, 2, 0},
            new(){ 1, 0, 1, 0, 0},
        };

        var result = solution.CountMoreThanTwoOverlaps(map);

        result.Should().Be(3);
    }
}
