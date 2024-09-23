namespace DayThree;

public class PartOne
{
    public int Execute(List<string> bytes)
    {
        var gammaRate = GetGammaRate(bytes);
        var epsilonRate = GetEpsilonRate(gammaRate);

        var gammaRateConverted = Convert.ToInt32(gammaRate, 2);
        var gepsilonRateConverted = Convert.ToInt32(epsilonRate, 2);

        return gammaRateConverted * gepsilonRateConverted;
    }

    public string GetGammaRate(List<string> bytes)
    {
        var totalColumns = bytes.First().Length;
        var currentColumn = 0;

        var bitValidator = new BitValidator();

        var bitResult = string.Empty;

        do
        {
            for (int currentLine = 0; currentLine < bytes.Count; currentLine++)
            {
                var currentBit = char.GetNumericValue(bytes[currentLine][currentColumn]);

                if (bytes.IndexOf(bytes[currentLine]) + 1 == bytes.Count)
                {
                    bitValidator.ValidateNumber(currentBit);
                    bitResult += bitValidator.ValidateQuantityOfNumbers();
                    currentColumn++;
                    break;
                }
                bitValidator.ValidateNumber(currentBit);
            }
        } while (currentColumn < totalColumns);
        return bitResult;
    }

    public string GetEpsilonRate(string gammaRate)
    {
        var result = string.Empty;
        foreach (var bit in gammaRate) 
        {
            if (bit == '0')
            {
                result += "1";
            }
            if (bit == '1')
            {
                result += "0";
            }
        }
        return string.IsNullOrEmpty(result) 
            ? throw new ArgumentException("Cannot Convert Epsilon Rate.")
            : result;
    }
}
