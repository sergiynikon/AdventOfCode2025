using AdventOfCode2025.Puzzles;

namespace UnitTests;

public class Day1Tests
{
    private readonly IPuzzle _solver = new Day1();

    [Fact]
    public void Case1()
    {
        // Arrange
        var input = """
                    L68
                    L30
                    R48
                    L5
                    R60
                    L55
                    L1
                    L99
                    R14
                    L82
                    """;
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        var part2 = result[1];

        Assert.Equal("3", part1);
        Assert.Equal("6", part2);
    }

    [Fact]
    public void Case2()
    {
        // Arrange
        var input = """
                    L50
                    R100
                    L100
                    """;
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        var part2 = result[1];

        Assert.Equal("3", part1);
        Assert.Equal("3", part2);
    }

    [Fact]
    public void Case3()
    {
        // Arrange
        var input = """
                    L51
                    R1
                    """;
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        var part2 = result[1];

        Assert.Equal("1", part1);
        Assert.Equal("2", part2);
    }

    [Fact]
    public void Case4()
    {
        // Arrange
        var input = """
                    L51
                    R300
                    L500
                    """;
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        var part2 = result[1];

        Assert.Equal("0", part1);
        Assert.Equal("9", part2);
    }

    [Fact]
    public void Case5()
    {
        // Arrange
        var input = """
                    L50
                    R300
                    R600
                    """;
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part1 = result[0];
        var part2 = result[1];

        Assert.Equal("3", part1);
        Assert.Equal("10", part2);
    }

    [Theory]
    [MemberData(nameof(RotationRight_Part2Cases))]
    [MemberData(nameof(RotationLeft_Part2Cases))]
    [MemberData(nameof(RotationsMixed_Part2Cases))]
    public void Part2Cases(string input, string expectedPart2)
    {
        // Act
        var result = _solver.Solve(input);

        // Assert
        var part2 = result[1];

        Assert.Equal(expectedPart2, part2);
    }

    public static IEnumerable<object[]> RotationRight_Part2Cases()
    {
        yield return
        [
            """
            R50
            R50
            R50
            """, "2"
        ];

        yield return
        [
            """
            R50
            R100
            R250
            R50
            """, "5"
        ];

        yield return
        [
            """
            R51
            R100
            R250
            R48
            """, "4"
        ];
    }

    public static IEnumerable<object[]> RotationLeft_Part2Cases()
    {
        yield return
        [
            """
            L50
            L100
            """, "2"
        ];

        yield return
        [
            """
            L50
            L1
            """, "1"
        ];

        yield return
        [
            """
            L1
            L50
            """, "1"
        ];

        yield return
        [
            """
            L250
            """, "3"
        ];

        yield return
        [
            """
            L50
            L100
            L100
            L200
            """, "5"
        ];

        yield return
        [
            """
            L49
            L1
            L1
            L99
            L1
            """, "2"
        ];
    }

    public static IEnumerable<object[]> RotationsMixed_Part2Cases()
    {
        yield return
        [
            """
            L50
            L1
            R1
            L1
            R1
            """, "3"
        ];

        yield return
        [
            """
            L49
            L1
            R1
            L1
            """, "2"
        ];

        yield return
        [
            """
            L49
            L100
            R100
            L200
            R200
            L1
            """, "7"
        ];
    }
}