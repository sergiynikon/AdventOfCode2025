namespace AdventOfCode2025.Puzzles;

public class Day4 : IPuzzle
{
    private const int RollsThreshold = 4;
    public string[] Solve(string input)
    {
        var cafeteria = ParseInput(input);

        var part1Result = SolvePart1(cafeteria);
        var part2Result = SolvePart2(cafeteria);

        return [part1Result.ToString(), part2Result.ToString()];
    }

    private int SolvePart1(bool[][] cafeteria)
    {
        int accessibleRollsNumber = 0;

        for (int y = 0; y < cafeteria.Length; y++)
        {
            for (int x = 0; x < cafeteria[0].Length; x++)
            {
                if (cafeteria[y][x])
                {
                    if (GetNeighbouringItemsCount(cafeteria, y, x) < RollsThreshold)
                    {
                        accessibleRollsNumber++;
                    }
                }
            }
        }

        return accessibleRollsNumber;
    }

    private int SolvePart2(bool[][] cafeteria)
    {
        int accessibleRollsNumber = 0;

        bool isRemovedInLoop;
        do
        {
            isRemovedInLoop = false;
            for (int y = 0; y < cafeteria.Length; y++)
            {
                for (int x = 0; x < cafeteria[0].Length; x++)
                {
                    if (cafeteria[y][x])
                    {
                        if (GetNeighbouringItemsCount(cafeteria, y, x) < RollsThreshold)
                        {
                            accessibleRollsNumber++;
                            cafeteria[y][x] = false;
                            isRemovedInLoop = true;
                        }
                    }
                }
            }
        } while (isRemovedInLoop);

        return accessibleRollsNumber;
    }

    private int GetNeighbouringItemsCount(bool[][] cafeteria, int y, int x)
    {
        int minX = x - 1 < 0 ? 0 : x - 1;
        int minY = y - 1 < 0 ? 0 : y - 1;
        int maxX = x + 1 >= cafeteria[0].Length - 1 ? cafeteria[0].Length - 1 : x + 1;
        int maxY = y + 1 >= cafeteria.Length - 1 ? cafeteria.Length - 1 : y + 1;

        int count = 0;

        for (int yy = minY; yy <= maxY; yy++)
        {
            for (int xx = minX; xx <= maxX; xx++)
            {
                // Skip self
                if (yy == y && xx == x)
                    continue;
                
                if (cafeteria[yy][xx])
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static bool[][] ParseInput(string input)
    {
        var result = new List<bool[]>();

        if (string.IsNullOrWhiteSpace(input))
            return result.ToArray();

        var lines = input.Split([Environment.NewLine], StringSplitOptions.None);
        result.AddRange(lines.Select(line => line.Select(c => c == '@').ToArray()));

        return result.ToArray();
    }
}