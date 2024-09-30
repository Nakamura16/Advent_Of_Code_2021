namespace DayFive.Helper;

public static class MatrixCreator
{
    public static List<List<int>> CreateMatrix(int matrixSize)
    {
        var line = new List<int>();
        var matrix = new List<List<int>>();
        for (int i = 0; i < matrixSize; i++)
        {
            line.Add(0);
        }

        for (int i = 0; i < matrixSize; i++)
        {
            matrix.Add(new(line));
        }
        return matrix;
    }
}
