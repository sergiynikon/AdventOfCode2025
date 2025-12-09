using System.Globalization;
using System.Security.Cryptography;

namespace AdventOfCode2025.Puzzles;

public class Day8 : IPuzzle
{
    private readonly struct Coordinate(long x, long y, long z) : IEquatable<Coordinate>
    {
        public long X { get; } = x;
        public long Y { get; } = y;
        public long Z { get; } = z;

        public double DistanceTo(Coordinate other)
        {
            return Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y) + (Z - other.Z) * (Z - other.Z));
        }

        public bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object? obj)
        {
            return obj is Coordinate other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }
    }
    public string[] Solve(string input)
    {
        return SolveInternal(input, 1000);
    }

    public string[] Solve(string input, int connectionsCount)
    {
        return SolveInternal(input, connectionsCount);
    }

    private string[] SolveInternal(string input, int connectionsCount)
    {
        var junctionBoxesCoordinates = ParseInput(input);

        var part1Result = SolvePart1(junctionBoxesCoordinates, connectionsCount);
        var part2Result = SolvePart2(junctionBoxesCoordinates);

        return [part1Result.ToString(), part2Result.ToString()];
    }

    private long SolvePart1(Coordinate[] coordinates, int connectionsCount)
    {
        HashSet<(Coordinate c1, Coordinate c2, double distance)> pairs = [];

        for (int i = 0; i < coordinates.Length - 1; i++)
        {
            for (int j = i + 1; j < coordinates.Length; j++)
            {
                double distance = coordinates[i].DistanceTo(coordinates[j]);
                pairs.Add((coordinates[i], coordinates[j], distance));
            }
        }

        var sortedPairs = pairs.OrderBy(p => p.distance).ToList();


        int currentlyConnectedCount = 0;
        HashSet<HashSet<Coordinate>> chains = new HashSet<HashSet<Coordinate>>();

        int pairsIndex = 0;

        while (currentlyConnectedCount < connectionsCount && pairsIndex < sortedPairs.Count)
        {
            var existingChain1 = chains.SingleOrDefault(chain => chain.Contains(sortedPairs[pairsIndex].c1));
            var existingChain2 = chains.SingleOrDefault(chain => chain.Contains(sortedPairs[pairsIndex].c2));

            if (existingChain1 != null && existingChain2 != null)
            {
                if (!Equals(existingChain1, existingChain2))
                {
                    // connect chains
                    foreach (var coordinate in existingChain2)
                    {
                        existingChain1.Add(coordinate);
                    }
                    chains.Remove(existingChain2);
                }
            }
            else if (existingChain1 != null && existingChain2 == null)
            {
                existingChain1.Add(sortedPairs[pairsIndex].c2);
            }
            else if (existingChain2 != null && existingChain1 == null)
            {
                existingChain2.Add(sortedPairs[pairsIndex].c1);
            }
            else
            {
                HashSet<Coordinate> newChain = [sortedPairs[pairsIndex].c1, sortedPairs[pairsIndex].c2];
                chains.Add(newChain);
            }

            pairsIndex++;
            currentlyConnectedCount++;
        }

        var product = chains.OrderByDescending(chain => chain.Count).Take(3).Aggregate(1, (current, chain) => current * chain.Count);

        return product;
    }
    private long SolvePart2(Coordinate[] coordinates)
    {
        HashSet<(Coordinate c1, Coordinate c2, double distance)> pairs = [];

        for (int i = 0; i < coordinates.Length - 1; i++)
        {
            for (int j = i + 1; j < coordinates.Length; j++)
            {
                double distance = coordinates[i].DistanceTo(coordinates[j]);
                pairs.Add((coordinates[i], coordinates[j], distance));
            }
        }

        var sortedPairs = pairs.OrderBy(p => p.distance).ToList();


        int currentlyConnectedCount = 0;
        HashSet<HashSet<Coordinate>> chains = new HashSet<HashSet<Coordinate>>();

        int pairsIndex = 0;

        (Coordinate c1, Coordinate c2, double distance) lastPair = sortedPairs[0];

        while (chains.Count != 1 || chains.SelectMany(x => x).Count() != coordinates.Length)
        {
            var existingChain1 = chains.SingleOrDefault(chain => chain.Contains(sortedPairs[pairsIndex].c1));
            var existingChain2 = chains.SingleOrDefault(chain => chain.Contains(sortedPairs[pairsIndex].c2));

            if (existingChain1 != null && existingChain2 != null)
            {
                if (!Equals(existingChain1, existingChain2))
                {
                    // connect chains
                    foreach (var coordinate in existingChain2)
                    {
                        existingChain1.Add(coordinate);
                    }
                    chains.Remove(existingChain2);
                }
            }
            else if (existingChain1 != null && existingChain2 == null)
            {
                existingChain1.Add(sortedPairs[pairsIndex].c2);
            }
            else if (existingChain2 != null && existingChain1 == null)
            {
                existingChain2.Add(sortedPairs[pairsIndex].c1);
            }
            else
            {
                HashSet<Coordinate> newChain = [sortedPairs[pairsIndex].c1, sortedPairs[pairsIndex].c2];
                chains.Add(newChain);
            }

            lastPair = sortedPairs[pairsIndex];

            pairsIndex++;
            currentlyConnectedCount++;
        }

        var result = lastPair.c1.X * lastPair.c2.X;

        return result;
    }

    private Coordinate[] ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine);
        List<Coordinate> coordinates = new List<Coordinate>();
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            coordinates.Add(new Coordinate(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2])));
        }

        return coordinates.ToArray();
    }
}