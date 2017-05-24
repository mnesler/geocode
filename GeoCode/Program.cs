using GeoCode.DataBase;
using GeoCode.Helpers;
using GeoCode.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace GeoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("TestData/input.txt"))
                {
                    string line;
                    List<string> file = new List<string>();

                    while ((line = sr.ReadLine()) != null)
                    {
                        file.Add(line);
                    }
                    //the first line of the input is a string of coordinates, we need to parse these into something usable.
                    //In this case its a mapping of the general direction and the x,y plot.
                    Dictionary<string, Point> coordinateMap = GeoCoordinateParser.ParseCoordinatesToMap(file[0]);

                    //represents the region to search in
                    var areaBox = new AreaBox(coordinateMap);

                    for (int i = 1; i < file.Count; i++)
                    {
                        var geoCodeRetriver = new GeoCodeRetriever();
                        //this is the google maps api call
                        var geoCode = geoCodeRetriver.GeoCodeRetrieveAddress(file[i]);

                        //similar to the coordinateMap, however only one point is given
                        var point = new Point(geoCode.results[0].geometry.location.lat, geoCode.results[0].geometry.location.lng);

                        //is this in the areaBox region?
                        if (areaBox.PointExists(point))
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
