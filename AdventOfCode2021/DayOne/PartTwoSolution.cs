namespace DayOne;

public class PartTwoSolution
{
    public IReadOnlyList<int> TranformMeasurements(IReadOnlyList<int> measurements)
    {
        var tranformMeasurements = new List<int>();
        for (int i = 0; i < (measurements.Count - 2); i++)
        {
            var sumOfThreeMeasurement = measurements[i] + measurements[i + 1] + +measurements[i + 2];
            tranformMeasurements.Add(sumOfThreeMeasurement);
        }
        return tranformMeasurements;
    }
}
