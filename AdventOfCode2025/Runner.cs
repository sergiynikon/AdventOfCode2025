using AdventOfCode2025.Factories;

namespace AdventOfCode2025;

public class Runner
{
    private const string DefaultPuzzleName = "Day1";
    private const string InputFilePath = "Input.txt";
    private readonly IPuzzleFactory _puzzleFactory;

    public Runner(IPuzzleFactory puzzleFactory)
    {
        _puzzleFactory = puzzleFactory;
    }

    public void Run()
    {
        var puzzle = _puzzleFactory.Resolve(DefaultPuzzleName);
        if (puzzle is null)
        {
            Console.WriteLine($"Puzzle '{DefaultPuzzleName}' not found.");
            return;
        }

        string input = File.ReadAllText(InputFilePath);
        string[] result = puzzle.Solve(input);

        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine($"Part {i + 1} Result: {result[i]}");
        }
    }
}