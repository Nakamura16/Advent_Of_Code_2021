namespace DayThree;

public class PartTwo
{
    public string GetOxygenGeneratorRating(List<string> bytes)
    {
        var bits = new List<string>(bytes);
        var bitValidator = new BitValidator();

        var currentColumn = 0;

        do
        {
            for (int currentLine = 0; currentLine < bits.Count; currentLine++)
            {
                var currentBit = char.GetNumericValue(bits[currentLine][currentColumn]);
                var isTheLastNumberOfTheColumn = bits.IndexOf(bits[currentLine]) + 1 == bits.Count;

                if (isTheLastNumberOfTheColumn)
                {
                    bitValidator.CheckNumber(currentBit);
                    bits = RemoveNumbers(bits, currentColumn, bitValidator.ValidateQuantityOfNumbers());
                    currentColumn++;
                    break;
                }
                bitValidator.CheckNumber(currentBit);
            }
        } while (bits.Count != 1);

        return bits.Single();
    }

    public List<string> RemoveNumbers(List<string> bytes, int column, string mostCommonBit)
    {
        var filteredNumbers = bytes.Where(bit => bit[column].ToString() != mostCommonBit);
        return bytes.Except(filteredNumbers).ToList();
    }
}
