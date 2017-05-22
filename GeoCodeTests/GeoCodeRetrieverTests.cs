using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using GeoCode.DataBase;

namespace GeoCodeTests
{
    //NUnit 2 Test Adapter
    //https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnitTestAdapter
    [TestClass]
    public class GeoCodeRetrieverTests
    {
        private GeoCodeRetriever _sut;
        [SetUp]
        public void SetUp()
        {
            _sut = new GeoCodeRetriever();
        }
        [Test]
        public void GeoCodeRetrieveAddress()
        {
            _sut.GeoCodeRetrieveAddress("1600 Amphitheatre Pkwy, Mountain View, CA 94043");
        }
    }
}
