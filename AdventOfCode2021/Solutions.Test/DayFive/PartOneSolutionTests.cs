using DayFive.Model;
using DayFive.Solutions;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayFive;

public class PartOneSolutionTests
{
    private readonly PartOneSolution solution = new();

    [Fact] 
    public void MarkAllLineSegments_WithHorizontalLineSegment_ShoulFillMapCorrectly()
    {
        var map = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };

        var lineSegments = new List<LineSegment>() { new(new(2,1), new(2, 3)) };

        solution.MarkAllLineSegments(lineSegments, map);

        var expectedMap = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 1, 1, 1, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };
        map.Should().BeEquivalentTo(expectedMap);
    }

    [Fact]
    public void MarkAllLineSegments_WithVerticalLineSegment_ShoulFillMapCorrectly()
    {
        var map = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };

        var lineSegments = new List<LineSegment>() { new(new(1, 2), new(3, 2)) };

        solution.MarkAllLineSegments(lineSegments, map);

        var expectedMap = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 1, 0, 0},
            new(){ 0, 0, 1, 0, 0},
            new(){ 0, 0, 1, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };
        map.Should().BeEquivalentTo(expectedMap);
    }

    [Fact]
    public void MarkAllLineSegments_DiagonalLineSegment_ShouldIgnoreAndNotMark()
    {
        var map = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };

        var lineSegments = new List<LineSegment>() { new(new(1, 1), new(3, 3)) };

        solution.MarkAllLineSegments(lineSegments, map);

        var expectedMap = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };
        map.Should().BeEquivalentTo(expectedMap);
    }

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

        var result = solution.VerifyResult(map);

        result.Should().Be(3);
    }
}
