using AdventOfCode2025.Puzzles;

namespace UnitTests;

public class Day2Tests
{
    private readonly IPuzzle _solver = new Day2();

    [Fact]
    public void Part1ExampleCase()
    {
        // Arrange
        var input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        Assert.Equal("1227775554", part1);
    }

    [Theory]
    [InlineData("3-21", "11")]
    [InlineData("95-115", "99")]
    [InlineData("11-22", "33")]
    [InlineData("123122-123124", "123123")]
    [InlineData("6463-6465", "6464")]
    [InlineData("55-55", "55")]
    [InlineData("0101-0101", "0")]
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
        var input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal("4174379265", part2);
    }

    [Theory]
    [InlineData("11-22", "33")]
    [InlineData("95-115", "210")]
    [InlineData("998-1012", "2009")]
    [InlineData("1188511880-1188511890", "1188511885")]
    [InlineData("1698522-1698528", "0")]
    [InlineData("446443-446449", "446446")]
    [InlineData("565653-565659", "565656")]
    [InlineData("2121212118-2121212124", "2121212121")]
    [InlineData("222220-222224", "222222")]
    public void Part2Cases(string input, string expectedResult)
    {
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal(expectedResult, part2);
    }
}