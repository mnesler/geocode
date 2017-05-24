using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GeoCode.Helpers
{
    public class GeoCoordinateParser
    {
        public static Dictionary<string, double[]> ParseCoordinatesToMap(string coordinateString)
        {
            var map = new Dictionary<string, double[]>();
            if (string.IsNullOrEmpty(coordinateString))
            {
                return map;
            }
            else
            {
                var cleanerString = coordinateString.Trim();
                var regex = new Regex(@"(\d+\.\d+)|(-\d+\.\d+)");
                var matches = regex.Matches(cleanerString);
                if (matches.Count > 0)
                {
                    double[] xPoints = { Convert.ToDouble(matches[0].Value), Convert.ToDouble(matches[2].Value), Convert.ToDouble(matches[4].Value), Convert.ToDouble(matches[6].Value)};
                    double[] yPoints = { Convert.ToDouble(matches[1].Value), Convert.ToDouble(matches[3].Value), Convert.ToDouble(matches[5].Value), Convert.ToDouble(matches[7].Value)};
                    map.Add("X", xPoints);
                    map.Add("Y", yPoints);
                }
            }
            return map;
        }
    }
}
