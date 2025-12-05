using AdventOfCode2025.Puzzles;

namespace UnitTests;

public class Day4Tests
{
    private readonly IPuzzle _solver = new Day4();

    [Fact]
    public void Part1ExampleCase()
    {
        // Arrange
        var input = """
                    ..@@.@@@@.
                    @@@.@.@.@@
                    @@@@@.@.@@
                    @.@@@@..@.
                    @@.@@@@.@@
                    .@@@@@@@.@
                    .@.@.@.@@@
                    @.@@@.@@@@
                    .@@@@@@@@.
                    @.@.@@@.@.
                    """;

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        Assert.Equal("13", part1);
    }

    [Theory]
    [InlineData("""
                ..@
                ..@
                ..@
                """, "3")]
    [InlineData("""
                .@@
                .@@
                ..@
                """, "3")]
    [InlineData("""
                @@@
                @@@
                @@@
                """, "4")]
    [InlineData("""
                @.@
                @@.
                @.@
                """, "5")]
    public void Part1Cases(string input, string expectedResult)
    {
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        Assert.Equal(expectedResult, part1);
    }

    [Fact]
    public void Part2ExampleCase()
    {
        // Arrange
        var input = """
                    ..@@.@@@@.
                    @@@.@.@.@@
                    @@@@@.@.@@
                    @.@@@@..@.
                    @@.@@@@.@@
                    .@@@@@@@.@
                    .@.@.@.@@@
                    @.@@@.@@@@
                    .@@@@@@@@.
                    @.@.@@@.@.
                    """;

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal("43", part2);
    }

    [Theory]
    [InlineData("""
                .@@
                .@@
                ..@
                """, "5")]
    [InlineData("""
                @@@
                @@@
                @@@
                """, "9")]
    [InlineData("""
                @@@@
                @@@@
                @@@@
                @@@@
                """, "4")]
    public void Part2Cases(string input, string expectedResult)
    {
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal(expectedResult, part2);
    }
}