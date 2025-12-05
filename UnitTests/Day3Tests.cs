using AdventOfCode2025.Puzzles;

namespace UnitTests;

public class Day3Tests
{
    private readonly IPuzzle _solver = new Day3();

    [Fact]
    public void Part1ExampleCase()
    {
        // Arrange
        var input = """
                    987654321111111
                    811111111111119
                    234234234234278
                    818181911112111
                    """;

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        Assert.Equal("357", part1);
    }

    [Theory]
    [InlineData("987654321111111", "98")]
    [InlineData("811111111111119", "89")]
    [InlineData("234234234234278", "78")]
    [InlineData("818181911112111", "92")]
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
                    987654321111111
                    811111111111119
                    234234234234278
                    818181911112111
                    """;

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal("3121910778619", part2);
    }

    [Theory]
    [InlineData("987654321111111", "987654321111")]
    [InlineData("811111111111119", "811111111119")]
    [InlineData("234234234234278", "434234234278")]
    [InlineData("818181911112111", "888911112111")]
    public void Part2Cases(string input, string expectedResult)
    {
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal(expectedResult, part2);
    }
}