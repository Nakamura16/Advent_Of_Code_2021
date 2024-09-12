namespace FileReader;

public class FileReader
{
    public IReadOnlyList<string> ReadFile(string filePath)
    {
        var lines = File.ReadLines(filePath).ToList();
        if (!lines.Any())
        {
            throw new Exception("The current file is empty.");
        }
        return lines;
    }
}
