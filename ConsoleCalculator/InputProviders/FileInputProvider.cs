using ConsoleCalculator.Model;

namespace ConsoleCalculator.InputProviders;

public class FileInputProvider : IInputProvider
{
    private readonly string filePath;

    public FileInputProvider(string filePath)
    {
        this.filePath = filePath;
    }

    public IEnumerable<OperationData> GetOperations()
    {
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (!string.IsNullOrWhiteSpace(line))
            {
                yield return ParseLine(i, line);
            }
        }
    }

    private OperationData ParseLine(int lineIndex, string line)
    {
        var splitted = line.Trim().Split(' ');
        if (splitted.Length != 2)
        {
            throw new InvalidOperationException($"Operation on the line {lineIndex} is not valid.");
        }

        return new OperationData
        {
            Name = splitted[0],
            Argument = double.Parse(splitted[1])
        };
    }
}