using DayFive.Application.Impl;
using DayFive.Model;
using FluentAssertions;
using Xunit;
namespace Solutions.Test.DayFive;

public class LineSegmentMarkerTests
{
    private readonly LineSegmentMarker marker = new();

    [Fact]
    public void MarkHorizontalAndVerticalLineSegments_WithHorizontalLineSegment_ShoulFillMapCorrectly()
    {
        var map = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };

        var lineSegments = new List<LineSegment>() { new(new(2, 1), new(2, 3)) };

        marker.MarkHorizontalAndVerticalLineSegments(lineSegments, map);

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
    public void MarkHorizontalAndVerticalLineSegments_WithVerticalLineSegment_ShoulFillMapCorrectly()
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

        marker.MarkHorizontalAndVerticalLineSegments(lineSegments, map);

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
    public void MarkHorizontalAndVerticalLineSegments_DiagonalLineSegment_ShouldIgnoreAndNotMark()
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

        marker.MarkHorizontalAndVerticalLineSegments(lineSegments, map);

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

    [Theory]
    [MemberData(nameof(GetDiagonalLineSegmentsCoordinates))]
    public void GetDiagonalDirection_WithUpRightDiagonalSegment_ShouldReturnTheCorrectDirection(
        Coordinate start, 
        Coordinate end, 
        DiagonalDirections direction)
    {
        var lineSegment = new LineSegment(start, end);

        var result = marker.GetLineSegmentPosition(lineSegment);

        result.Should().Be(direction);
    }

    public static TheoryData<Coordinate,Coordinate, DiagonalDirections> GetDiagonalLineSegmentsCoordinates()
    {
        return new TheoryData<Coordinate, Coordinate, DiagonalDirections>()
        {
            { new(1, 1), new(2, 2), DiagonalDirections.DownRight},
            { new(1, 2), new(2, 1), DiagonalDirections.DownLeft},
            { new(2, 1), new(1, 2), DiagonalDirections.UpRight},
            { new(2, 2), new(1, 1), DiagonalDirections.UpLeft},
        };
    }

    [Fact]
    public void MarkDiagonalLineSegment_WithDiagonalDownRight_ShouldMarkCorrectly()
    {
        var map = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };

        var lineSegment = new LineSegment(new(1, 1), new(3, 3));

        marker.MarkDiagonalLineSegment(map, lineSegment);

        var expectedMap = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 1, 0, 0, 0},
            new(){ 0, 0, 1, 0, 0},
            new(){ 0, 0, 0, 1, 0},
            new(){ 0, 0, 0, 0, 0},
        };
        map.Should().BeEquivalentTo(expectedMap);
    }

    [Fact]
    public void MarkDiagonalLineSegment_WithDiagonalDownLeft_ShouldMarkCorrectly()
    {
        var map = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };

        var lineSegment = new LineSegment(new(1, 3), new(4, 0));

        marker.MarkDiagonalLineSegment(map, lineSegment);

        var expectedMap = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 1, 0},
            new(){ 0, 0, 1, 0, 0},
            new(){ 0, 1, 0, 0, 0},
            new(){ 1, 0, 0, 0, 0},
        };
        map.Should().BeEquivalentTo(expectedMap);
    }

    [Fact]
    public void MarkDiagonalLineSegment_WithDiagonalUpRight_ShouldMarkCorrectly()
    {
        var map = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };

        var lineSegment = new LineSegment(new(4, 0), new(1, 3));

        marker.MarkDiagonalLineSegment(map, lineSegment);

        var expectedMap = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 1, 0},
            new(){ 0, 0, 1, 0, 0},
            new(){ 0, 1, 0, 0, 0},
            new(){ 1, 0, 0, 0, 0},
        };
        map.Should().BeEquivalentTo(expectedMap);
    }

    [Fact]
    public void MarkDiagonalLineSegment_WithDiagonalUpLeft_ShouldMarkCorrectly()
    {
        var map = new List<List<int>>()
        {
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
            new(){ 0, 0, 0, 0, 0},
        };

        var lineSegment = new LineSegment(new(3, 3), new(0, 0));

        marker.MarkDiagonalLineSegment(map, lineSegment);

        var expectedMap = new List<List<int>>()
        {
            new(){ 1, 0, 0, 0, 0},
            new(){ 0, 1, 0, 0, 0},
            new(){ 0, 0, 1, 0, 0},
            new(){ 0, 0, 0, 1, 0},
            new(){ 0, 0, 0, 0, 0},
        };
        map.Should().BeEquivalentTo(expectedMap);
    }
}
