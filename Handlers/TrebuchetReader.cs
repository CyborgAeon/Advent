using System.Text.RegularExpressions;

namespace Advent.Handlers
{
    public static class TrebuchetReader
    {
        private static Regex firstDigit = new Regex("\\d");
        private static Regex lastDigitRegex = new Regex("\\d(?=\\D*$)");

        public static int GetCoordinates(string path)
        {
            int coordinates = 0;
            foreach (var line in File.ReadLines(path))
            {
               coordinates += GetCoordinate(line);
            }
            return coordinates;
        }

        private static int GetCoordinate(string line)
        {
            var coordinateAsString = $"{firstDigit.Match(line).Value}{lastDigitRegex.Match(line).Value}";
            return int.Parse(coordinateAsString);
        }
    }
}
