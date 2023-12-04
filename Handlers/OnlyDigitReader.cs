using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.Handlers
{
    public class OnlyDigitReader : TrebuchetReader
    {
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
            List<int> coordinates = new List<int>();
            for (int i = 0; i < numberOfNumbersToFind; i++)
            {
                coordinates.AddRange(ReadValues(line, i == 0));
            }

            return coordinates.First() * 10 + coordinates.Last();
        }

        protected IEnumerable<int> ReadValues(string line, bool isFirst)
        {
            var match = isFirst ? firstDigitRegex.Match(line).Value : lastDigitRegex.Match(line).Value;
            yield return int.Parse(match);
        }
    }
}
