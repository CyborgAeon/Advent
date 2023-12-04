using System.Text.RegularExpressions;

namespace Advent.Handlers
{
    public class AlphabetAndDigitReader : TrebuchetReader
    {
        private Regex firstWordyNumberRegex = new Regex("(?:zero|one|two|three|four|five|six|seven|eight|nine)|\\d");
        private Regex lastWordyNumberRegex = new Regex("(?:zero|one|two|three|four|five|six|seven|eight|nine)(?=\\D*$)");

        public int GetCoordinates(string path)
        {
            int coordinates = 0;
            foreach (var line in File.ReadLines(path))
            {
                coordinates += GetCoordinate(line, 2);
            }
            return coordinates;
        }

        public int GetCoordinate(string line, int numberOfNumbersToFind)
        {
            var first = ReadValues(line, true).First() * 10;
            var second = ReadValues(line, false).First();
            return first + second;
        }

        public IEnumerable<int> ReadValues(string line, bool isFirst)
        {
            if (IsWordy(line, isFirst))
            {
                var match = isFirst ?
                    firstWordyNumberRegex.Match(line).Value :
                    lastWordyNumberRegex.Matches(line).Last().Value;
                yield return match switch
                {
                    "zero" => 0,
                    "one" => 1,
                    "two" => 2,
                    "three" => 3,
                    "four" => 4,
                    "five" => 5,
                    "six" => 6,
                    "seven" => 7,
                    "eight" => 8,
                    "nine" => 9
                };
            }
            else
            {
                var match = isFirst ? firstDigitRegex.Match(line).Value : lastDigitRegex.Match(line).Value;
                yield return int.Parse(match);
            }
        }

        private bool IsWordy(string line, bool isFirst)
        {
            var wordRegex = isFirst ? firstWordyNumberRegex : lastWordyNumberRegex;
            var numberRegex = isFirst ? firstDigitRegex : lastDigitRegex;

            var wordIndex = wordRegex.Match(line).Index;
            var numberIndex = numberRegex.Match(line).Index;

            return isFirst ? wordIndex < numberIndex : wordIndex > numberIndex;
        }
    }
}
