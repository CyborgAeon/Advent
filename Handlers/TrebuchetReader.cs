﻿using System.Text.RegularExpressions;

namespace Advent.Handlers
{
    public class TrebuchetReader
    {        
        protected Regex firstDigitRegex = new Regex("\\d");
        protected Regex lastDigitRegex = new Regex("\\d(?=\\D*$)");

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

        protected IEnumerable<int> ReadValues(string line, bool numberOfNumbersToFind) => throw new NotImplementedException();
        //private int SetTens(string line)
        //{
        //    //MapWordyNumber(line);
        //    //int.Parse(firstDigit.Match(line).Value) * 10;
        //}
        //private int SetUnits(string line) => int.Parse(lastDigitRegex.Match(line).Value);
    }
}
