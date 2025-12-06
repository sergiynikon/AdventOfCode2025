using AdventOfCode2025.Puzzles;

namespace UnitTests;

public class Day6Tests
{
    private readonly IPuzzle _solver = new Day6();

    [Fact]
    public void Part1ExampleCase()
    {
        // Arrange
        var input = """
                    123 328  51 64 
                     45 64  387 23 
                      6 98  215 314
                    *   +   *   +  
                    """;

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        Assert.Equal("4277556", part1);
    }

    [Theory]
    [InlineData("""
                1
                2
                3
                4
                *
                """, "24")]
    [InlineData("""
                1
                2
                3
                4
                +
                """, "10")]
    [InlineData("""
                1 2
                2 3
                3 4
                4 5
                + +
                """, "24")]
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
                    123 328  51 64 
                     45 64  387 23 
                      6 98  215 314
                    *   +   *   +  
                    """;

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal("3263827", part2);
    }

    [Theory]
    [InlineData("""
                1
                2
                3
                4
                *
                """, "1234")]
    [InlineData("""
                1
                2
                3
                4
                +
                """, "1234")]
    [InlineData("""
                12
                23
                34
                45
                +
                """, "3579")]
    [InlineData("""
                 2
                 3
                34
                45
                +
                """, "2379")]
    public void Part2Cases(string input, string expectedResult)
    {
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal(expectedResult, part2);
    }
}