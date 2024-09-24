using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayThree;

public class PartTwo
{
    public string GetOxygenGeneratorRating(List<string> bytes)
    {
        var bits = new List<string>(bytes);
        var totalColumns = bits.First().Length;
        var bitResult = string.Empty;

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
                    bitResult += bitValidator.ValidateQuantityOfNumbers();
                    currentColumn++;
                    break;
                }
                bitValidator.CheckNumber(currentBit);
            }
        } while (currentColumn < totalColumns);
        return bitResult;
    }

    public List<string> RemoveNumbers(List<string> bytes, int column, string bitToRemove)
    {
        var filteredNumbers = bytes.Where(bit => bit[column - 1].ToString() == bitToRemove);
        return bytes.Except(filteredNumbers).ToList();
    }
}
