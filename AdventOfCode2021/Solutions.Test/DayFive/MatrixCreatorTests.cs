using DayFive.Helper;
using FluentAssertions;
using Xunit;

namespace Solutions.Test.DayFive;

public class MatrixCreatorTests
{
    [Fact]
    public void CreateMatrix_ShouldCreateAMatrixWithCorrectSizeAndFullFilledWithZeros()
    {
        var matrixSize = 5;
        var result = MatrixCreator.CreateMatrix(matrixSize);

        result.Count.Should().Be(matrixSize);
        result.First().Count.Should().Be(matrixSize);

        foreach (var line in result)
        {
            foreach (var element in line)
            {
                element.Should().Be(0);
            }
        }
    }
}
