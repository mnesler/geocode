using GeoCode.Models;

namespace GeoCode
{
    public static class PolygonMath
    {
        //https://stackoverflow.com/questions/217578/how-can-i-determine-whether-a-2d-point-is-within-a-polygon
        //not going to pretend i know everything about this solution, however i did research it a bit and this was the most elegant 
        public static bool PointExistsInPoly(int numberOfPolygonVertices, double[] xPolygonCoord, double[] yPolygonCoord, Point testPoint)
        {

            var i = 0;
            var j = 0;
            var c = false;  //this is a binary flag that gets switched for each intersection in the poly 
            for (i = 0, j = numberOfPolygonVertices - 1; i < numberOfPolygonVertices; j = i++)
            {
                if (((yPolygonCoord[i] > testPoint.longitude) != (yPolygonCoord[j] > testPoint.longitude))
                    && (testPoint.latitude < (xPolygonCoord[j] - xPolygonCoord[i]) * (testPoint.longitude - yPolygonCoord[i]) / (yPolygonCoord[j] - yPolygonCoord[i]) + xPolygonCoord[i]))
                {
                    c = !c;
                }
            }
            return c;
        }
    }
}
