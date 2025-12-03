using AdventOfCode2025.Puzzles;

namespace AdventOfCode2025.Factories;

public interface IPuzzleFactory
{
    IPuzzle? Resolve(string name);
}