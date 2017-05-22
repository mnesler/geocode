using GeoCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCode
{
    public class GeoCoordinateParser
    {
        //(Latitude, Longitude)
        //(37.5, -122.5), (38.2, -121.6), (37.0, -121.4), (36.6, -121.3)

        static public AreaBox ParseCoordinates(string coordinateString)
        {
            string cleanerString = coordinateString.Trim();
           // Latitude: max / min + 90 to - 90
           // Longitude: max / min + 180 to - 180
            if (string.IsNullOrEmpty(coordinateString))
            {
                return new AreaBox(0.0, 0.0, 0.0, 0.0);
            }
            //do work here:
            //return the object
            return new AreaBox(0.0, 0.0, 0.0, 0.0);
        }
    }
}
