using System.Text.RegularExpressions;

namespace Advent.Handlers
{
    public static class TrebuchetReader
    {
        private static Regex firstWordyNumberRegex = new Regex("(?:zero|one|two|three|four|five|six|seven|eight|nine)|\\d");
        private static Regex lastWordyNumberRegex = new Regex("\\b(?:zero|one|two|three|four|five|six|seven|eight|nine)\\b(?=\\D*$)");
        private static Regex firstDigitRegex = new Regex("\\d");
        private static Regex lastDigitRegex = new Regex("\\d(?=\\D*$)");

        public static int GetCoordinates(string path)
        {
            int coordinates = 0;
            foreach (var line in File.ReadLines(path))
            {
                coordinates += GetCoordinate(line, 2);
            }
            return coordinates;
        }

        private static int GetCoordinate(string line, int numberOfNumbersToFind)
        {
            List<int> coordinates = new List<int>();
            for (int i = 0; i < numberOfNumbersToFind; i++)
            {
                coordinates.AddRange(MapWordyNumber(line, i == 0));
            }

            return coordinates.First() * 10 + coordinates.Last();
        }

        //private static int SetTens(string line)
        //{
        //    //MapWordyNumber(line);
        //    //int.Parse(firstDigit.Match(line).Value) * 10;
        //}
        //private static int SetUnits(string line) => int.Parse(lastDigitRegex.Match(line).Value);

        private static IEnumerable<int> MapWordyNumber(string line, bool isFirst)
        {
            if (IsWordy(line, isFirst))
            {
                var match = isFirst ? 
                    firstWordyNumberRegex.Match(line).Value : 
                    lastWordyNumberRegex.Match(line).Value;
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

        private static bool IsWordy(string line, bool isFirst)
        {
            var wordRegex = isFirst ? firstWordyNumberRegex : lastWordyNumberRegex;
            var numberRegex = isFirst ? firstDigitRegex : lastDigitRegex;
            
            var wordIndex = wordRegex.Match(line).Index;
            var numberIndex = numberRegex.Match(line).Index;

            return isFirst ? wordIndex < numberIndex : wordIndex > numberIndex;
        }
    }
}
