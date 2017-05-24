using System;
using System.Net.Http;


namespace GeoCode.DataBase
{
    public class GeoCodeRetriever
    {
        readonly HttpClient _client;
        public GeoCodeRetriever()
        {
            _client = new HttpClient();
        }
        public Models.GeoCode GeoCodeRetrieveAddress(string address)
        {
            var geoCode = new Models.GeoCode();
            if (!string.IsNullOrEmpty(address))
            {
                try
                {
                    using (_client)
                    {
                        var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key=AIzaSyD8rrhmAGCl28sFl-IwYeTNYBRlJU327YU";
                        var response = _client.GetAsync(url).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            //having trouble with ReadAsAsync?
                            //http://stackoverflow.com/questions/10399324/where-is-httpcontent-readasasync
                            //install-package Microsoft.AspNet.WebApi.Client
                            geoCode = response.Content.ReadAsAsync<Models.GeoCode>().Result;
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return geoCode;
        }
    }
}
