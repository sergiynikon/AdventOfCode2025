using System.Diagnostics;

namespace AdventOfCode2025.Puzzles
{
    public class Day1 : IPuzzle
    {
        private record Rotation
        {
            public Direction Direction { get; set; }
            public int Value { get; set; }
        }

        private enum Direction
        {
            Left,
            Right
        }

        public string[] Solve(string input)
        {
            var rotations = ParseInput(input);

            int dial = 50;
            int zeroPointingNumber = 0;
            int zeroPointingNumbersIncludingRotation = 0;
            foreach (var rotation in rotations)
            {
                switch (rotation.Direction)
                {
                    case Direction.Right:
                        dial += rotation.Value;
                        zeroPointingNumbersIncludingRotation += dial / 100;
                        dial %= 100;
                        break;
                    case Direction.Left:
                        var previous = dial;
                        dial -= rotation.Value;

                        zeroPointingNumbersIncludingRotation += Math.Abs(dial) / 100;

                        if (previous > 0 && dial <= 0)
                        {
                            zeroPointingNumbersIncludingRotation++;
                        }

                        if (dial < 0)
                        {
                            dial = (dial % 100 + 100) % 100;
                        }

                        break;
                }

                if (dial == 0)
                {
                    zeroPointingNumber++;
                }
            }

            return [zeroPointingNumber.ToString(), zeroPointingNumbersIncludingRotation.ToString()];
        }

        private static List<Rotation> ParseInput(string input)
        {
            var result = new List<Rotation>();

            if (string.IsNullOrWhiteSpace(input))
                return result;

            var lines = input.Split(["\r\n", "\n"], StringSplitOptions.None);
            foreach (var raw in lines)
            {
                var line = raw.Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                var first = line[0];
                var dir = first switch
                {
                    'L' => Direction.Left,
                    'R' => Direction.Right,
                };

                var numberPart = line[1..].Trim();

                result.Add(new Rotation { Direction = dir, Value = int.Parse(numberPart) });
            }

            return result;
        }
    }
}
