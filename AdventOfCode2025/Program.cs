using AdventOfCode2025.Puzzles;
using System.Reflection;
using AdventOfCode2025;
using AdventOfCode2025.Factories;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var puzzleTypes = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => typeof(IPuzzle).IsAssignableFrom(t) && t is { IsClass: true, IsAbstract: false })
    .ToArray();

foreach (var t in puzzleTypes)
    services.AddTransient(t);

services.AddSingleton<IPuzzleFactory, PuzzleFactory>();
services.AddSingleton<Runner>();


var provider = services.BuildServiceProvider();

var runner = provider.GetRequiredService<Runner>();
runner.Run();