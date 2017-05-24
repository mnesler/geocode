using GeoCode.DataBase;
using GeoCode.Helpers;
using GeoCode.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //read from input file, 
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
                    Dictionary<string, Point> coordinateMap = GeoCoordinateParser.ParseCoordinatesToMap(file[0]);
                    var areaBox = new AreaBox(coordinateMap);

                    var addressList = new List<string>();
                    for (int i = 1; i < file.Count; i++)
                    {
                        addressList.Add(file[i]);
                        var geoCodeRetriver = new GeoCodeRetriever();
                        var geoCode = geoCodeRetriver.GeoCodeRetrieveAddress(file[i]);

                        var point = new Point(geoCode.results[0].geometry.location.lat, geoCode.results[0].geometry.location.lng);
                        if(areaBox.PointExists(point))
                        {
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
