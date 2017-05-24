using GeoCode.Models;
using System;
using System.Text.RegularExpressions;

namespace GeoCode
{
    public class AreaBoxFactory
    {
        public static AreaBox CreateAreaBox(MatchCollection matches)
        {
            var northWestPoint = new Point(Convert.ToDouble(matches[0].Value), Convert.ToDouble(matches[1].Value));
            var northEastPoint = new Point(Convert.ToDouble(matches[2].Value), Convert.ToDouble(matches[3].Value));
            var southEastPoint = new Point(Convert.ToDouble(matches[4].Value), Convert.ToDouble(matches[5].Value));
            var southWestPoint = new Point(Convert.ToDouble(matches[6].Value), Convert.ToDouble(matches[7].Value));
            return new AreaBox(northWestPoint, northEastPoint, southEastPoint, southWestPoint);
        }
    }
}
