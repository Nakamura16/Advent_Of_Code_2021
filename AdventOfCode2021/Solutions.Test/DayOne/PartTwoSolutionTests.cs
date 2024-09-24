using DayOne;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Solutions.Test.DayOne;

public class PartTwoSolutionTests
{
    private readonly PartTwoSolution partTwoSolution = new();
    private readonly List<int> testData = new() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

    [Fact]
    public void TranformMeasurements_ShouldReturnTheTotalSumOfThreeMeasurementSliding()
    {
        var result = partTwoSolution.TranformMeasurements(testData);

        var expectedResult = new List<int> (){ 607, 618, 618, 617, 647, 716, 769, 792 };
        result.Should().BeEquivalentTo(expectedResult);
    }
}
