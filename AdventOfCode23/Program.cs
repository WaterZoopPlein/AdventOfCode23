using AdventOfCode23Day;
using System.Diagnostics;

namespace AdventOfCode23;

public class Program
{
    public static void Main(string[] args)
    {
        var day = new Day02(); // Replace date number here

        solve(day);
    }
    private static void solve(IDay day)
    {
        Console.WriteLine("Initialise");
        var watchInnit = Stopwatch.StartNew();
        day.Initialise();
        watchInnit.Stop();

        Console.WriteLine("Part 1");
        var watch1 = Stopwatch.StartNew();
        day.SolvePartOne();
        watch1.Stop();

        Console.WriteLine("Part 2");
        var watch2 = Stopwatch.StartNew();
        day.SolvePartTwo();
        watch2.Stop();

        Console.WriteLine($"Innit took {watchInnit.Elapsed}");
        Console.WriteLine($"Part One took {watch1.Elapsed}");
        Console.WriteLine($"Part Two took {watch2.Elapsed}");

        Console.ReadLine();
    }

}