using System.Text.RegularExpressions;
using AdventOfCode23Common;

namespace AdventOfCode23Day
{
    public class Day01 : IDay
    {
        private List<string> _inputList = new();
        public void Initialise()
        {
            _inputList = ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day01.txt", "\n");
        }

        public void SolvePartOne()
        {
            Console.WriteLine(GetSumValueByDigitOnly(_inputList));
        }

        public void SolvePartTwo()
        {
            Console.WriteLine(GetSumValueByDigitAndWord(_inputList));
        }

        public int GetSumValueByDigitOnly(List<string> calibrationList)
        {
            return calibrationList.Sum(GetCalibrationValueByDigitOnly);
        }

        public int GetSumValueByDigitAndWord(List<string> calibrationList)
        {
            return calibrationList.Sum(GetCalibrationValueByDigitAndWord);
        }

        public int GetCalibrationValueByDigitOnly(string calibration)
        {
            int value = 0;
            foreach (var item in calibration)
            {
                if (!char.IsDigit(item)) continue;
                value += 10 * (item - 48);
                break;
            }

            for (var j = calibration.Length - 1; j >= 0; j--)
            {
                if (!char.IsDigit(calibration[j])) continue;
                value += calibration[j] - 48;
                break;
            }

            return value;
        }

        public int GetCalibrationValueByDigitAndWord(string calibration)
        {
            string pattern = @"(?=(one|two|three|four|five|six|seven|eight|nine|\d))";
            var testRegex = new Regex(pattern);
            var matches = testRegex.Matches(calibration);

            var groupNames = new List<string>();
            for (int i = 0; i < matches.Count; i++)
            {
                groupNames.Add(matches[i].Groups[1].Value);
            }

            var firstDigit = convertToDigit(groupNames[0]);
            var lastDigit = convertToDigit(groupNames[^1]);

            return firstDigit * 10 + lastDigit;
        }

        private int convertToDigit(string input)
        {
            if (input.Length == 1)
            {
                return int.TryParse(input, out int result) 
                    ? result 
                    : throw new ArgumentException($"Conversion {input} attempted.");
            }
            var digitDictionary = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            return digitDictionary.TryGetValue(input, out var value) 
                ? value
                : throw new ArgumentException($"Conversion {input} attempted.");
        }
    }
}