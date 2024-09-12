namespace FileReader.Application;

public class FileReaderTool
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
