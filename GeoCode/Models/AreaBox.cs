using System.Collections.Generic;

namespace GeoCode.Models
{
    public class AreaBox
    {
        Point NorthWestPoint { get; set; }
        Point NorthEastPoint { get; set; }
        Point SouthEastPoint { get; set; }
        Point SouthWestPoint { get; set; }

        public AreaBox(Point northWestPoint, Point northEastPoint, Point southEastPoint, Point southWestPoint)
        {
            NorthWestPoint = northWestPoint;
            NorthEastPoint = northEastPoint;
            SouthEastPoint = southEastPoint;
            SouthWestPoint = southWestPoint;
        }
        public AreaBox()
        {
            NorthWestPoint = new Point(0.0, 0.0);
            NorthEastPoint = new Point(0.0, 0.0);
            SouthEastPoint = new Point(0.0, 0.0);   
            SouthWestPoint = new Point(0.0, 0.0);
        }
        public AreaBox(Dictionary<string, Point> coordinateMap)
        {
            NorthWestPoint = coordinateMap["NorthWest"];
            NorthEastPoint = coordinateMap["NorthEast"];
            SouthEastPoint = coordinateMap["SouthEast"];
            SouthWestPoint = coordinateMap["SouthWest"];
        }

        //I think this should be outside in another class.
        public bool PointExists(Point point)
        {
            if ( (point.latitude <= NorthWestPoint.latitude && point.latitude >= SouthWestPoint.latitude )
                && (point.longitude >= NorthEastPoint.longitude && point.longitude <= SouthEastPoint.longitude)) {
                return true;
            }
            return false;
        }
    } 
}
