using AdventOfCode2025.Puzzles;

namespace UnitTests;

public class Day8Tests
{
    private readonly Day8 _solver = new Day8();

    [Fact]
    public void Part1ExampleCase()
    {
        // Arrange
        var input = """
                    162,817,812
                    57,618,57
                    906,360,560
                    592,479,940
                    352,342,300
                    466,668,158
                    542,29,236
                    431,825,988
                    739,650,466
                    52,470,668
                    216,146,977
                    819,987,18
                    117,168,530
                    805,96,715
                    346,949,466
                    970,615,88
                    941,993,340
                    862,61,35
                    984,92,344
                    425,690,689
                    """;

        // Act
        var result = _solver.Solve(input, 10);

        // Assert
        var part1 = result[0];
        Assert.Equal("40", part1);
    }

    [Theory]
    [InlineData("""
                1,1,1
                2,2,2
                """, 1, "2")]
    [InlineData("""
                1,1,1
                2,2,2
                4,4,4
                """, 2, "3")]
    [InlineData("""
                1,1,1
                2,2,2
                4,4,4
                8,8,8
                9,9,9
                """, 2, "4")]
    public void Part1Cases(string input, int connectionsCount, string expectedResult)
    {
        // Act
        var result = _solver.Solve(input, connectionsCount);

        // Assert
        var part1 = result[0];
        Assert.Equal(expectedResult, part1);
    }

    [Fact]
    public void Part2ExampleCase()
    {
        // Arrange
        var input = """
                    162,817,812
                    57,618,57
                    906,360,560
                    592,479,940
                    352,342,300
                    466,668,158
                    542,29,236
                    431,825,988
                    739,650,466
                    52,470,668
                    216,146,977
                    819,987,18
                    117,168,530
                    805,96,715
                    346,949,466
                    970,615,88
                    941,993,340
                    862,61,35
                    984,92,344
                    425,690,689
                    """;

        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];
        Assert.Equal("25272", part2);
    }
}