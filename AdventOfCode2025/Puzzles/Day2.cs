using System.Text;
using static AdventOfCode2025.Puzzles.Day1;

namespace AdventOfCode2025.Puzzles;

public class Day2 : IPuzzle
{
    public string[] Solve(string input)
    {
        var ranges = ParseInput(input);
        var part1 = SolvePart1(ranges);
        var part2 = SolvePart2(ranges);

        return [part1.ToString(), part2.ToString()];
    }

    private static long SolvePart1(List<string[]> ranges)
    {
        long sum = 0;
        foreach (var range in ranges)
        {
            long rangeSum = 0;
            long min = long.Parse(range[0]);
            long max = long.Parse(range[1]);

            long halfMin = 1;
            long halfMax = range[1].Length % 2 == 0 
                ? long.Parse(range[1][..(range[1].Length / 2)]) 
                : long.Parse(range[1][..(range[1].Length / 2 + 1)]);

            for (long current = halfMin; current <= halfMax; current++)
            {
                long combined = long.Parse($"{current}{current}");
                if (combined >= min && combined <= max)
                {
                    rangeSum += combined;
                }
            }

            sum += rangeSum;
        }

        return sum;
    }

    private static long SolvePart2(List<string[]> ranges)
    {
        long sum = 0;
        foreach (var range in ranges)
        {
            var invalidIds = new List<string>();
            long min = long.Parse(range[0]);
            long max = long.Parse(range[1]);

            long halfMax = range[1].Length % 2 == 0
                ? long.Parse(range[1][..(range[1].Length / 2)])
                : long.Parse(range[1][..(range[1].Length / 2 + 1)]);

            for (long current = 1; current <= halfMax; current++)
            {
                StringBuilder combinedRaw1 = new();

                while (combinedRaw1.Length < range[1].Length)
                {
                    combinedRaw1.Append(current);
                }

                long combined = long.Parse(combinedRaw1.ToString());

                StringBuilder combinedRaw2 = new();

                while (combinedRaw2.Length < range[1].Length - 1)
                {
                    combinedRaw2.Append(current);
                }

                long combined2 = long.Parse(combinedRaw2.ToString());


                if (combined >= min && combined <= max)
                {
                    invalidIds.Add(combined.ToString());
                }
                else if (combined2 >= min && combined2 <= max)
                {
                    invalidIds.Add(combined2.ToString());
                }
            }

            sum += invalidIds.Distinct().Sum(long.Parse);
        }

        return sum;
    }

    private static List<string[]> ParseInput(string input)
    {
        var result = new List<string[]>();

        if (string.IsNullOrWhiteSpace(input))
            return result;

        var parts = input.Split([","], StringSplitOptions.None);
        foreach (var raw in parts)
        {
            var rangesRaw = raw.Trim();

            var rangesParts = rangesRaw.Split(["-"], StringSplitOptions.None);
            var left = rangesParts[0];
            var right = rangesParts[1];

            result.Add([left, right]);
        }

        return result;
    }
}