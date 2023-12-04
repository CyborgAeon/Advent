using System;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advent.Handlers
{
    public class AlphabetAndDigitReader : TrebuchetReader
    {
        public int GetCoordinates(string path)
        {
            int coordinates = 0;
            foreach (var line in File.ReadLines(path))
            {
                coordinates += GetCoordinate(line);
            }
            return coordinates;
        }

        public string ReadCharsInString(string chars, Dictionary<string, int> numbers)
        {
            int characterIndex = 0;
            int output = 0;
            foreach (var cha in chars)
            {
                var sub = chars.AsSpan(characterIndex++);
                foreach (var number in numbers)
                {
                    if (sub.StartsWith(number.Key))
                    {
                        output = number.Value;
                        return output.ToString();
                    }
                }

                // character 48 is 0; character 57 is 9;
                // This if statement does a lookup to check if the
                // current character in question is a digit
                // if it is, we assign that digit to output and return it.
                // 48 - 48 = 0; 49 - 48 = 1; 50 - 48 = 2...
                if ((int)cha >= 48 && (int)cha <= 57)
                {
                    output = ((int)cha) - 48;
                    break;
                }
            }
            return output.ToString();
        }

        public int GetCoordinate(string line)
        {
            var first = ReadCharsInString(line, A.Numbers);
            var second = ReadCharsInString(new string(line.Reverse().ToArray()),
                A.Numbers.ToDictionary(
                    k => new string(k.Key.Reverse().ToArray()), 
                    k => k.Value));

            return int.Parse(first + second);
        }
    }
}
