using AdventOfCode23Common;
using AdventOfCode23Day;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode23Tests
{
    [TestClass]
    public class TestDay01
    {
        private List<string> _testInputList01 = new();
        private List<string> _testInputList02 = new();
        private readonly Day01 _day01 = new();

        [TestInitialize]
        public void TestInit()
        {
            _testInputList01 = ReadInput.ConvertInputTextToStringList(@"..\..\..\..\TestInputs\Day01_01.txt", "\n");
            _testInputList02 = ReadInput.ConvertInputTextToStringList(@"..\..\..\..\TestInputs\Day01_02.txt", "\n");
        }

        [TestMethod]
        [DataRow("1abc2", 12)]
        [DataRow("pqr3stu8vwx", 38)]
        [DataRow("a1b2c3d4e5f", 15)]
        [DataRow("treb7uchet", 77)]
        public void TestDay01_GetCalibrationValueByDigitOnly(string inputString, int expected)
        {
            var actual = _day01.GetCalibrationValueByDigitOnly(inputString);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void TestDay01_GetSumValueByDigitOnly()
        {
            var actual = _day01.GetSumValueByDigitOnly(_testInputList01);

            actual.Should().Be(142);
        }

        [TestMethod]
        [DataRow("two1nine", 29)]
        [DataRow("eightwothree", 83)]
        [DataRow("abcone2threexyz", 13)]
        [DataRow("xtwone3four", 24)]
        [DataRow("4nineeightseven2", 42)]
        [DataRow("zoneight234", 14)]
        [DataRow("7pqrstsixteen", 76)]
        [DataRow("twone", 21)]
        public void TestDay01_GetCalibrationValueByDigitAndWord(string inputString, int expected)
        {
            var actual = _day01.GetCalibrationValueByDigitAndWord(inputString);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void TestDay01_GetSumValueByDigitAndWord()
        {
            var actual = _day01.GetSumValueByDigitAndWord(_testInputList02);

            actual.Should().Be(281);
        }
    }
}