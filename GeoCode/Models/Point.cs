using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCode.Models
{
    public class Point
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Point(double x, double y)
        {
            latitude = x;
            longitude = y;
        }
    }
}
