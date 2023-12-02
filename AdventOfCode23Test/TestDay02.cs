using AdventOfCode23Day;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace AdventOfCode23Test;


[TestClass]
public class TestDay02
{
    private readonly Day02 _day02 = new();

    [TestInitialize]
    public void TestInit()
    {

    }

    [TestMethod]
    [DataRow("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        4, 2, 6)]
    [DataRow("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        1, 3, 4)]
    [DataRow("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        20, 13, 6)]
    [DataRow("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        14, 3, 15)]
    [DataRow("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        6, 3, 2)]
    public void TestDay02_DeductMinimumCubeFromGameString
        (string gameString, int expectedRed, int expectedGreen, int expectedBlue)
    {
        var actual = _day02.DeductMinimumCubes(gameString);

        actual["blue"].Should().Be(expectedBlue);
        actual["red"].Should().Be(expectedRed);
        actual["green"].Should().Be(expectedGreen);
    }
}