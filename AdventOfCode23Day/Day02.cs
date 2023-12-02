using System.Text.RegularExpressions;
using AdventOfCode23Common;

namespace AdventOfCode23Day;

public class Day02 : IDay
{
    private List<string> _inputList = new();
    private string _inputString = "";
    private List<Dictionary<string, int>> _minimumCubesBagList = new();

    public void Initialise()
    {
        _inputList = ReadInput.ConvertInputTextToStringLineList(@"..\..\..\..\Inputs\Day02.txt");
        var regex = new Regex(@"(?<=Game\s\d*:\s).*");
        var matches = regex.Matches(_inputString);
        for (int i = 0; i < matches.Count; i++)
        {
            _inputList.Add(matches[i].Value);
        }

        _minimumCubesBagList = _inputList.Select(DeductMinimumCubes).ToList();
    }

    public void SolvePartOne()
    {
        var thresholdDict = new Dictionary<string, int>
        {
            { "blue", 14 },
            { "red", 12 },
            { "green", 13 }
        };

        int idSum = 0;
        for (int i = 0; i < _minimumCubesBagList.Count; i++)
        {
            var isExceedingThreshold =
                _minimumCubesBagList[i]["blue"] > thresholdDict["blue"] ||
                _minimumCubesBagList[i]["red"] > thresholdDict["red"] ||
                _minimumCubesBagList[i]["green"] > thresholdDict["green"];
            if (!isExceedingThreshold)
            {
                idSum += i + 1;
            }
        }

        Console.WriteLine(idSum);
    }

    public void SolvePartTwo()
    {
        long powerSum = 0;
        for (int i = 0; i < _minimumCubesBagList.Count; i++)
        {
            powerSum +=
                _minimumCubesBagList[i]["blue"]
                * _minimumCubesBagList[i]["red"]
                * _minimumCubesBagList[i]["green"];
        }

        Console.WriteLine(powerSum);
    }

    public Dictionary<string, int> DeductMinimumCubes(string gameString)
    {
        var regex = new Regex(@"(?<=Game\s\d*:\s).*");
        var match = regex.Matches(gameString)[0].Value;

        var outputDict = new Dictionary<string, int>
        {
            { "blue", 0 },
            { "red", 0 },
            { "green", 0 }
        };

        foreach (var hand in match.Split(',', ';'))
        {
            var splitHand = hand.Trim().Split(" ");
            outputDict[splitHand[1]] =
                outputDict[splitHand[1]] < int.Parse(splitHand[0])
                    ? int.Parse(splitHand[0])
                    : outputDict[splitHand[1]];
        }

        return outputDict;
    }
}