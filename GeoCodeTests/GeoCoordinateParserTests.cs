using GeoCode;
using GeoCode.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace GeoCodeTests
{
        [TestClass]
        public class GeoCoordinateParserTests
        {
            private GeoCoordinateParser _sut;
            [SetUp]
            public void SetUp()
            {
                _sut = new GeoCoordinateParser();
            }
            [Test]
            public void GeoCodeRetrieveAddress()
            {
            var s = GeoCoordinateParser.ParseCoordinatesToMap("(37.5, -122.5), (38.2, -121.6), (37.0, -121.4), (36.6, -121.3)");
            }
        }
}
