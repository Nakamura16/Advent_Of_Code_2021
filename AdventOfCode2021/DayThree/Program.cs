using DayThree;
using FileReader.Application;

internal class Program
{
    public static void Main(string[] args)
    {

        var reader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\DayThree\\Input.txt";

        var bytes = reader.ReadFile(filePath).ToList();
        var totalColumns = bytes.First().Length;
        var currentColumn = 0;

        var bitValidator = new BitValidator();

        var bitResult = string.Empty;

        do
        {
            foreach (var item in bytes)
            {
                var currentBit = char.GetNumericValue(item[currentColumn]);

                if (bytes.IndexOf(item) == bytes.Count)
                {
                    bitValidator.ValidateNumber(currentBit);
                    bitResult += bitValidator.ValidateQuantityOfNumbers();
                    currentColumn++;
                }
                bitValidator.ValidateNumber(currentBit);
            }
        } while (currentColumn <= totalColumns);

        Console.WriteLine($"Solution for Part One: {bitResult}");
    }
}