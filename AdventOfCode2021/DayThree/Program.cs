using FileReader.Application;

internal class Program
{
    public static void Main(string[] args)
    {

        var reader = new FileReaderTool();
        var filePath = "C:\\Users\\andre\\Desktop\\estudos C#\\"
            + "Advent_Of_Code_2021\\AdventOfCode2021\\DayThree\\Input.txt";

        var bytes = reader.ReadFile(filePath).ToList();
        var lineSize = bytes.First().Length;
        var currentBitColumn = 0;

        var numbersZeroQuantity = 0;
        var numbersOnesQuantity = 0;

        var bit = string.Empty;

        do
        {
            foreach (var item in bytes)
            {
                var currentBit = char.GetNumericValue(item[currentBitColumn]);

                if (currentBit == 0)
                {
                    numbersZeroQuantity++;
                }
                else if (currentBit == 1)
                {
                    numbersOnesQuantity++;
                }
                else if(bytes.IndexOf(item) == bytes.Count)
                {
                    if (numbersZeroQuantity > numbersOnesQuantity)
                    {
                        bit += "0";
                    }
                    else 
                    {
                        bit += "1";
                    }
                    numbersZeroQuantity = 0;
                    numbersOnesQuantity = 0;
                    currentBitColumn ++;
                }
            }
        } while (currentBitColumn <= lineSize);

        Console.WriteLine($"Solution for Part One: {bit}");

    }
}