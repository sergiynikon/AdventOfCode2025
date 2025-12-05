using AdventOfCode2025.Puzzles;

namespace UnitTests;

public class Day5Tests
{
    private readonly IPuzzle _solver = new Day5();

    [Fact]
    public void Part1ExampleCase()
    {
        // Arrange
        var input = """
                    3-5
                    10-14
                    16-20
                    12-18

                    1
                    5
                    8
                    11
                    17
                    32
                    """;

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        Assert.Equal("3", part1);
    }

    [Theory]
    [InlineData("""
                3-5

                1
                2
                3
                """, "1")]
    [InlineData("""
                30-50

                29
                30
                31
                49
                50
                51
                """, "4")]
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
                    3-5
                    10-14
                    16-20
                    12-18

                    1
                    5
                    8
                    11
                    17
                    32
                    """;

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal("14", part2);
    }

    [Theory]
    [InlineData("""
                3-5

                1
                """, "3")]
    [InlineData("""
                3-5
                4-6

                1
                """, "4")]
    [InlineData("""
                3-5
                5-8

                1
                """, "6")]
    public void Part2Cases(string input, string expectedResult)
    {
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal(expectedResult, part2);
    }
}