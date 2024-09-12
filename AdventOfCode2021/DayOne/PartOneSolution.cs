namespace DayOne;

internal class PartOneSolution
{
    public int Run(IList<int> depthMeasurements)
    {
        var previousMeasurement = depthMeasurements.First();
        int biggerMeasurements = 0;

        foreach (var measurement in depthMeasurements)
        {
            if (measurement > previousMeasurement)
            {
                biggerMeasurements++;
            }
            previousMeasurement = measurement;
        }
        return biggerMeasurements;
    }
}
