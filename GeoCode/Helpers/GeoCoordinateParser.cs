using GeoCode.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GeoCode.Helpers
{
    public class GeoCoordinateParser
    {
        static public Dictionary<string, Point> ParseCoordinatesToMap(string coordinateString)
        {
            var map = new Dictionary<string, Point>();
            if (string.IsNullOrEmpty(coordinateString))
            {
                return map;
            }
            else
            {
                string cleanerString = coordinateString.Trim();
                Regex regex = new Regex(@"(\d+\.\d+)|(-\d+\.\d+)");
                MatchCollection matches = regex.Matches(cleanerString);
                if (matches.Count > 0)
                {
                    map.Add("NorthWest", new Point(Convert.ToDouble(matches[0].Value), Convert.ToDouble(matches[1].Value)));
                    map.Add("NorthEast", new Point(Convert.ToDouble(matches[2].Value), Convert.ToDouble(matches[3].Value)));
                    map.Add("SouthEast", new Point(Convert.ToDouble(matches[4].Value), Convert.ToDouble(matches[5].Value)));
                    map.Add("SouthWest", new Point(Convert.ToDouble(matches[6].Value), Convert.ToDouble(matches[7].Value)));
                }
            }
            return map;
        }
    }
}
