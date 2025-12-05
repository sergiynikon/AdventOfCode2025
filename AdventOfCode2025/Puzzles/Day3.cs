using System.Diagnostics;
using System.Text;

namespace AdventOfCode2025.Puzzles;

public class Day3 : IPuzzle
{
    public string[] Solve(string input)
    {
        var joltageRatings = ParseInput(input);

        var part1Result = SolvePart1(joltageRatings);
        var part2Result = SolvePart2(joltageRatings);

        return [part1Result, part2Result];
    }

    private static string SolvePart1(List<int[]> joltageRatings) => GetLargestJoltage(joltageRatings, 2);
    private static string SolvePart2(List<int[]> joltageRatings) => GetLargestJoltage(joltageRatings, 12);

    private static string GetLargestJoltage(List<int[]> joltageRatings, int numOfBatteries)
    {
        long sum = 0;

        foreach (var rating in joltageRatings)
        {
            StringBuilder ratingRowSumBuilder = new();

            int num1;
            int num1Index = 0;

            for (int i = 0; i < numOfBatteries; i++)
            {
                num1 = rating[num1Index];
                for (int j = num1Index + 1; j < rating.Length - numOfBatteries + i + 1; j++)
                {
                    if (rating[j] > num1)
                    {
                        num1Index = j;
                        num1 = rating[j];
                    }
                }

                ratingRowSumBuilder.Append(num1);
                num1Index++;
            }

            sum += long.Parse(ratingRowSumBuilder.ToString());
        }

        return sum.ToString();
    }

    private static List<int[]> ParseInput(string input)
    {
        var result = new List<int[]>();

        if (string.IsNullOrWhiteSpace(input))
            return result;

        var lines = input.Split([Environment.NewLine], StringSplitOptions.None);
        result.AddRange(lines.Select(line => line.Select(c => c - '0').ToArray()));

        return result;
    }
}