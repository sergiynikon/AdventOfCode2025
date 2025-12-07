using System.Collections.Specialized;
using System.Diagnostics;

namespace AdventOfCode2025.Puzzles;

public class Day7 : IPuzzle
{
    private enum DiagramItem
    {
        EntryPoint,
        EmptySpace,
        Splitter
    }

    private class Timeline
    {
        public Timeline(int x, long count)
        {
            X = x;
            Count = count;
        }
        public int X { get; set; }
        public long Count { get; set; }
    }

    public string[] Solve(string input)
    {
        DateTimeOffset startTime = DateTimeOffset.Now;
        var diagram = ParseInput(input);

        var part1Result = SolvePart1(diagram);
        var part2Result = SolvePart2(diagram);

        DateTimeOffset endTime = DateTimeOffset.Now;

        Console.WriteLine(endTime - startTime);
        return [part1Result.ToString(), part2Result.ToString()];
    }

    private long SolvePart1(DiagramItem[,] diagram)
    {
        var splitsCount = 0;

        for (int x = 0; x < diagram.GetLength(0); x++)
        {
            for (int y = diagram.GetLength(1) - 1; y >= 0; y--)
            {
                if (diagram[x, y] == DiagramItem.Splitter)
                {
                    int splitterBelowY = -1;
                    var splitterExistsBelow = false;
                    for (int yy = y + 1; yy < diagram.GetLength(1); yy++)
                    {
                        if (diagram[x, yy] == DiagramItem.Splitter)
                        {
                            splitterExistsBelow = true;
                            splitterBelowY = yy;
                            break;
                        }
                    }

                    if (!splitterExistsBelow)
                    {
                        splitsCount++;
                    }
                    else
                    {
                        var neighbouringSplitterExistsBelow = false;
                        for (int yy = y + 1; yy < splitterBelowY; yy++)
                        {
                            var leftNeighbour = diagram[x - 1, yy];
                            var rightNeighbour = diagram[x + 1, yy];

                            if (leftNeighbour == DiagramItem.Splitter || rightNeighbour == DiagramItem.Splitter)
                            {
                                neighbouringSplitterExistsBelow = true;
                                break;
                            }
                        }

                        if (neighbouringSplitterExistsBelow)
                        {
                            splitsCount++;
                        }
                    }

                }
            }
        }

        return splitsCount;
    }

    private long SolvePart2(DiagramItem[,] diagram)
    {
        int entryPointX = -1;
        for (int i = 0; i < diagram.GetLength(0); i++)
        {
            if (diagram[i, 0] == DiagramItem.EntryPoint)
            {
                entryPointX = i;
                break;
            }
        }

        Timeline[] currentTimelines = [new(entryPointX, 1)];
        for (int y = 2; y < diagram.GetLength(1); y += 2)
        {
            List<Timeline> nextTimelines = [];
            foreach (var currentTimeline in currentTimelines)
            {
                if (diagram[currentTimeline.X, y] == DiagramItem.Splitter)
                {
                    if (nextTimelines.Exists(tl => tl.X == currentTimeline.X - 1))
                    {
                        nextTimelines.Single(tl => tl.X == currentTimeline.X - 1).Count += currentTimeline.Count;
                    }
                    else
                    {
                        nextTimelines.Add(new Timeline(currentTimeline.X - 1, currentTimeline.Count));
                    }

                    if (nextTimelines.Exists(tl => tl.X == currentTimeline.X + 1))
                    {
                        nextTimelines.Single(tl => tl.X == currentTimeline.X + 1).Count += currentTimeline.Count;
                    }
                    else
                    {
                        nextTimelines.Add(new Timeline(currentTimeline.X + 1, currentTimeline.Count));
                    }
                }
                else
                {
                    if (nextTimelines.Exists(tl => tl.X == currentTimeline.X))
                    {
                        nextTimelines.Single(tl => tl.X == currentTimeline.X).Count += currentTimeline.Count;
                    }
                    else
                    {
                        nextTimelines.Add(new Timeline(currentTimeline.X, currentTimeline.Count));
                    }
                }
            }

            currentTimelines = nextTimelines.ToArray();
        }

        return currentTimelines.Sum(tl => tl.Count);
    }

    //private int GetPathCounts(DiagramItem[,] diagram, int x, int y, int count)
    //{
    //    if (y == 0)
    //    {
    //        return diagram[x, y] == DiagramItem.EntryPoint ? 1 : 0;
    //    }

    //    if (diagram[x, y] == DiagramItem.Splitter)
    //    {
    //        return 0;
    //    }
    //    if (x - 1 >= 0 && diagram[x - 1, y] == DiagramItem.Splitter)
    //    {
    //        count += GetPathCounts(diagram, x - 1, y - 2, 0);
    //    }
    //    if (x + 1 < diagram.GetLength(0) && diagram[x + 1, y] == DiagramItem.Splitter)
    //    {
    //        count += GetPathCounts(diagram, x + 1, y - 2, 0);
    //    }

    //    if (diagram[x, y] == DiagramItem.EmptySpace)
    //    {
    //        count += GetPathCounts(diagram, x, y - 2, 0);
    //    }

    //    return count;
    //}

    private static DiagramItem[,] ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var yMax = lines.Length;
        var xMax = lines[0].Length;

        var diagram = new DiagramItem[xMax, yMax];

        for (var y = 0; y < yMax; y++)
        {
            for (var x = 0; x < xMax; x++)
            {
                diagram[x, y] = lines[y][x] switch
                {
                    '.' => DiagramItem.EmptySpace,
                    '^' => DiagramItem.Splitter,
                    'S' => DiagramItem.EntryPoint
                };
            }
        }

        return diagram;
    }
}