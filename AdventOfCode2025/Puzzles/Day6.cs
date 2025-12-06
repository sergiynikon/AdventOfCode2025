using System.Net.NetworkInformation;
using System.Text;

namespace AdventOfCode2025.Puzzles;

public class Day6 : IPuzzle
{
    private enum Operation
    {
        Multiply,
        Plus
    }

    public string[] Solve(string input)
    {
        var (numbers1, operations1) = ParseInputForPart1(input);
        var (numbers2, operations2) = ParseInputForPart2(input);

        var part1Result = SolvePart1(numbers1, operations1);
        var part2Result = SolvePart2(numbers2, operations2);

        return [part1Result.ToString(), part2Result.ToString()];
    }

    private long SolvePart1(long[][] numbers, Operation[] operations)
    {
        long resultSum = 0;

        for (long y = 0; y < numbers.Length; y++)
        {
            resultSum += ApplyOperation(numbers[y], operations[y]);
        }

        return resultSum;
    }

    private long SolvePart2(long[][] numbers, Operation[] operations)
    {
        long resultSum = 0;

        for (long y = 0; y < numbers.Length; y++)
        {
            resultSum += ApplyOperation(numbers[y], operations[y]);
        }

        return resultSum;
    }

    private long ApplyOperation(IEnumerable<long> numbers, Operation operation)
    {
        return numbers.Aggregate((num1, num2) => operation switch
        {
            Operation.Multiply => num1 * num2,
            Operation.Plus => num1 + num2,
        });
    }

    private static T[][] Transpose<T>(T[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        T[][] result = new T[cols][];
        for (int i = 0; i < cols; i++)
            result[i] = new T[rows];

        for (int r = 0; r < rows; r++)
        for (int c = 0; c < cols; c++)
            result[c][r] = matrix[r][c];

        return result;
    }

    private static (long[][] numbers, Operation[] operations) ParseInputForPart1(string input)
    {
        var firstIndexOfMultiply = input.IndexOf('*');
        var firstIndexOfPlus = input.IndexOf('+');
        firstIndexOfMultiply = firstIndexOfMultiply == -1 ? int.MaxValue : firstIndexOfMultiply;
        firstIndexOfPlus = firstIndexOfPlus == -1 ? int.MaxValue : firstIndexOfPlus;

        var firstIndexOfOperation = Math.Min(firstIndexOfMultiply, firstIndexOfPlus);

        var rawNumbers = input[..(firstIndexOfOperation)];
        var rawOperations = input[(firstIndexOfOperation)..];

        var numberLines = rawNumbers.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var numbers = numberLines.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray()).ToArray();
        var transposedNumbers = Transpose(numbers);

        var operations = rawOperations.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(ch => ch switch
        {
            "*" => Operation.Multiply,
            "+" => Operation.Plus
        }).ToArray();

        return (transposedNumbers, operations);
    }

    private static (long[][] numbers, Operation[] operations) ParseInputForPart2(string input)
    {
        var firstIndexOfMultiply = input.IndexOf('*');
        var firstIndexOfPlus = input.IndexOf('+');
        firstIndexOfMultiply = firstIndexOfMultiply == -1 ? int.MaxValue : firstIndexOfMultiply;
        firstIndexOfPlus = firstIndexOfPlus == -1 ? int.MaxValue : firstIndexOfPlus;

        var firstIndexOfOperation = Math.Min(firstIndexOfMultiply, firstIndexOfPlus);

        var rawNumbers = input[..firstIndexOfOperation];
        var rawOperations = input[firstIndexOfOperation..];

        var numberLinesChars = rawNumbers.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToCharArray()).ToArray();
        var transposedNumberLinesChars = Transpose(numberLinesChars);
        //var transposedNumberLines = transposedNumberLinesChars.Select(arr => new string(arr)).ToArray();

        List<List<long>> numbersList = [];
        var group = new List<long>();
        foreach (char[] line in transposedNumberLinesChars)
        {
            if (line.Any(x => x != 32))
            {
                group.Add(long.Parse(new string(line)));
            }
            else
            {
                numbersList.Add(group);
                group = [];
            }
        }

        numbersList.Add(group);

        var operations = rawOperations.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(ch => ch switch
        {
            "*" => Operation.Multiply,
            "+" => Operation.Plus
        }).ToArray();

        return (numbersList.Select(x => x.ToArray()).ToArray(), operations);
    }
}