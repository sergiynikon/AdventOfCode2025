namespace AdventOfCode2025.Puzzles;

public class Day5 : IPuzzle
{
    private class Range
    {
        public long Start { get; set; }
        public long End { get; set; }
        public bool Contains(long number) => number >= Start && number <= End;
        public long Sum => End - Start + 1;
        public override string ToString()
        {
            return $"{Start}-{End}";
        }
    }

    public string[] Solve(string input)
    {
        var (ranges, data) = ParseInput(input);

        var part1Result = SolvePart1(ranges, data);
        var part2Result = SolvePart2(ranges);

        return [part1Result.ToString(), part2Result.ToString()];
    }

    private int SolvePart1(Range[] ranges, long[] data)
    {
        int freshIngredientSum = 0;

        foreach (var number in data)
        {
            if (ranges.Any(r => r.Contains(number)))
            {
                freshIngredientSum++;
            }
        }

        return freshIngredientSum;
    }
    private long SolvePart2(Range[] ranges)
    {
        var optimizedRanges = OptimizeRanges(ranges);


        return optimizedRanges.Sum(x => x.Sum);
    }

    private Range[] OptimizeRanges(Range[] ranges)
    {
        var sortedRanges = ranges.OrderBy(x => x.Start).ToList();

        for (int i = 0; i < sortedRanges.Count; i++)
        {
            Range pivot = sortedRanges[i];
            for (int j = i + 1; j < sortedRanges.Count; j++)
            {
                Range compare = sortedRanges[j];
                if (pivot.Contains(compare.Start))
                {
                    long end = Math.Max(pivot.End, compare.End);
                    pivot.End = end;
                    sortedRanges.RemoveAt(j--);
                }
            }
        }

        return sortedRanges.ToArray();
    }

    private static (Range[] ranges, long[] data) ParseInput(string input)
    {
        var rangesAndDataLinesParts = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var rangesLines = rangesAndDataLinesParts[0].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var dataLines = rangesAndDataLinesParts[1].Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var ranges = rangesLines.Select(x =>
        {
            var parts = x.Split("-");
            var left = parts[0];
            var right = parts[1];
            return new Range
            {
                Start = long.Parse(left),
                End = long.Parse(right)
            };
        }).ToArray();

        var data = dataLines.Select(long.Parse).ToArray();


        return (ranges, data);
    }
}