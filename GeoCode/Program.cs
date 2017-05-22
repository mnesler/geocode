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
                    // Read the stream to a string, and write the string to the console.
                    string line = sr.ReadToEnd();
                    var areaBox = GeoCoordinateParser.ParseCoordinates($"(37.5, -122.5), (38.2, -121.6), (37.0, -121.4), (36.6, -121.3)");
                    //parse for /r/n chars
                    Console.WriteLine(line);
                }
            }
        catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            //parse into object

            //make call for each address object



            //AIzaSyD8rrhmAGCl28sFl-IwYeTNYBRlJU327YU
            //https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyD8rrhmAGCl28sFl-IwYeTNYBRlJU327YU

            //on return, 

            //is in box?

            //add to return collection

            //return
        }
    }
}
