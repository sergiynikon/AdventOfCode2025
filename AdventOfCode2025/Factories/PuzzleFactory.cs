using AdventOfCode2025.Puzzles;
using System.Reflection;

namespace AdventOfCode2025.Factories;

public class PuzzleFactory : IPuzzleFactory
{
    private readonly IServiceProvider _provider;
    private readonly Type[] _puzzleTypes;

    public PuzzleFactory(IServiceProvider provider)
    {
        _provider = provider;
        _puzzleTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IPuzzle).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .ToArray();
    }

    public IPuzzle? Resolve(string name)
    {
        var type = _puzzleTypes.FirstOrDefault(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase));
        if (type is null) return null;
        return _provider.GetService(type) as IPuzzle;
    }
}