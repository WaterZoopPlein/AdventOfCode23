namespace AdventOfCode23Common;

public class ReadInput
{
    public static List<int> ConvertInputTextToIntList(string path)
    {
        var lineList = ConvertInputTextToStringLineList(path);
        return lineList.Select(int.Parse).ToList();
    }

    public static List<long> ConvertInputTextToLongIntList(string path)
    {
        var lineList = ConvertInputTextToStringLineList(path);
        return lineList.Select(long.Parse).ToList();
    }

    public static List<string> ConvertInputTextToStringLineList(string path, string delimiter = "\n")
    {
        var textOutput = ReadString(path);
        var outputList = textOutput.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        return outputList;
    }

    public static IEnumerable<int> ConvertStringToIntIEnum(string str, char delimiter)
    {
        if (string.IsNullOrEmpty(str))
            yield break;

        foreach (var s in str.Split(delimiter))
        {
            if (int.TryParse(s, out int num))
                yield return num;
        }
    }

    public static int[,] ConvertInputStringListTo2DArray(List<string> input)
    {
        int[,] output2DArray = new int[input.Count, input[0].Length];
        for (int lineNumber = 0; lineNumber < input.Count; lineNumber++)
        {
            string line = input[lineNumber];
            for (int rowNumber = 0; rowNumber < line.Length; rowNumber++)
            {
                char digitChar = line[rowNumber];
                output2DArray[lineNumber, rowNumber] = (int)char.GetNumericValue(digitChar);
            }
        }
        return output2DArray;
    }

    public static string ReadString(string path)
    {
        string textOutput = "";
        try
        {
            using var sr = new StreamReader(path);
            textOutput = sr.ReadToEnd();

        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred whilst loading {Path.GetFullPath(path)}.");
            Console.WriteLine(e.Message);
        }

        return textOutput;
    }

}