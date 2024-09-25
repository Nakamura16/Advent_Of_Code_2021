namespace DayFour;

public record BingoCard(List<List<Number>> Numbers);

public class Number
{
    public int Value { get; set; }
    public bool IsChecked { get; set; }

    public Number(int value, bool isChecked = false)
    {
        Value = value;
        IsChecked = isChecked;
    }
};