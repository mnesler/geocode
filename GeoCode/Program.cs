using GeoCode.DataBase;
using GeoCode.Helpers;
using GeoCode.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace GeoCode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {   // Open the text file using a stream reader.
                using (var sr = new StreamReader(args[0]))
                {
                    string line;
                    var file = new List<string>();

                    while ((line = sr.ReadLine()) != null)
                    {
                        file.Add(line);
                    }
                    var coordinateMapXY = GeoCoordinateParser.ParseCoordinatesToMap(file[0]);
                    for (var i = 1; i < file.Count; i++)
                    {
                        //this is the google maps api call
                        var geoCodeRetriver = new GeoCodeRetriever();
                        var geoCode = geoCodeRetriver.GeoCodeRetrieveAddress(file[i]);

                        //this represents the lat and long of the address
                        var point = new Point(geoCode.results[0].geometry.location.lat, geoCode.results[0].geometry.location.lng);

                        //is this in the areaBox region?
                        if (PolygonMath.PointExistsInPoly(4, coordinateMapXY["X"], coordinateMapXY["Y"], point))
                        {
                            //output to user
                            Console.WriteLine(geoCode.results[0].formatted_address);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
