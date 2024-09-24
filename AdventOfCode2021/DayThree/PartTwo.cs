namespace DayThree;

public class PartTwo
{
    public int Execute(List<string> bytes)
    {
        var oxygenGeneratorRating = GetOxygenGeneratorRating(bytes);
        var co2ScrubberRating = GetCO2ScrubberRating(bytes);

        var convertedOxygen = Convert.ToInt32(oxygenGeneratorRating, 2);
        var convertedCo2 = Convert.ToInt32(co2ScrubberRating, 2);
        return convertedOxygen * convertedCo2;
    }

    public string GetOxygenGeneratorRating(List<string> bytes)
    {
        var bits = new List<string>(bytes);
        var bitValidator = new BitCounter();

        var currentColumn = 0;

        do
        {
            for (int currentLine = 0; currentLine < bits.Count; currentLine++)
            {
                var currentBit = char.GetNumericValue(bits[currentLine][currentColumn]);
                var isTheLastNumberOfTheColumn = bits.IndexOf(bits[currentLine]) + 1 == bits.Count;

                if (isTheLastNumberOfTheColumn)
                {
                    bitValidator.CountBit(currentBit);
                    bits = RemoveBits(bits, currentColumn, bitValidator.GetBitValue());
                    currentColumn++;
                    break;
                }
                bitValidator.CountBit(currentBit);
            }
        } while (bits.Count != 1);

        return bits.Single();
    }

    public string GetCO2ScrubberRating(List<string> bytes)
    {
        var bits = new List<string>(bytes);
        var bitValidator = new BitCounter();
        var partOne = new PartOne();

        var currentColumn = 0;

        do
        {
            for (int currentLine = 0; currentLine < bits.Count; currentLine++)
            {
                var currentBit = char.GetNumericValue(bits[currentLine][currentColumn]);
                var isTheLastNumberOfTheColumn = bits.IndexOf(bits[currentLine]) + 1 == bits.Count;

                if (isTheLastNumberOfTheColumn)
                {
                    bitValidator.CountBit(currentBit);
                    var reverseBit = partOne.GetEpsilonRate(bitValidator.GetBitValue());
                    bits = RemoveBits(bits, currentColumn, reverseBit);
                    currentColumn++;
                    break;
                }
                bitValidator.CountBit(currentBit);
            }
        } while (bits.Count != 1);

        return bits.Single();
    }

    public List<string> RemoveBits(List<string> bytes, int column, string bitToNotRemove)
    {
        var filteredNumbers = bytes.Where(bit => bit[column].ToString() != bitToNotRemove);
        return bytes.Except(filteredNumbers).ToList();
    }
}
