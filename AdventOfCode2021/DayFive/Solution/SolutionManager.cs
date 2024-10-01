using DayFive.Application;
using DayFive.Converter.Impl;
using DayFive.Helper;

namespace DayFive.Solution;

public class SolutionManager
{
    private readonly ILineSegmentConverter Converter;
    private readonly ILineSegmentMarker LineSegmentMarker;
    private readonly IOverlapCounter OverlapCounter;

    public SolutionManager(
        ILineSegmentConverter converter,
        ILineSegmentMarker lineSegmentMarker,
        IOverlapCounter overlapCounter)
    {
        Converter = converter;
        LineSegmentMarker = lineSegmentMarker;
        OverlapCounter = overlapCounter;
    }

    public int GetPartOneSolution(IList<string> file, int matrixSize)
    {
        var lineSegments = Converter.Convert(file);
        var map = MatrixCreator.CreateMatrix(matrixSize);
        LineSegmentMarker.MarkHorizontalAndVerticalLineSegments(lineSegments, map);
        return OverlapCounter.CountMoreThanTwoOverlaps(map);
    }

    public int GetPartTwoSolution(IList<string> file, int matrixSize)
    {
        var lineSegments = Converter.Convert(file);
        var map = MatrixCreator.CreateMatrix(matrixSize);
        LineSegmentMarker.MarkAllLineSegments(lineSegments, map);
        return OverlapCounter.CountMoreThanTwoOverlaps(map);
    }
}
