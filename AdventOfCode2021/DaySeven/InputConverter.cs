namespace DaySeven;

public class InputConverter
{
    public List<int> Convert(IList<string> input)
    {
        return input[0].Split(",")
            .Select(position => int.Parse(position))
            .ToList();
    }
}
