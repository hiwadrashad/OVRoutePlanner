using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.BLL.MainFunctions;

namespace UnitTests.Tests
{
    [TestFixture]
    public class NunitTests
    {

        [Test]
        [Category("GeoCoding")]
        public void TestGeoCodingGetLocation()
        {
            var coordinates =  GeoCoding.GetLocation("Utrecht centraal");
            Assert.AreNotEqual(0, coordinates.Latitude, "First coordinate is viable");
            Assert.AreNotEqual(0, coordinates.Longitude, "Last coordinate is viable");
        }

        [Test]
        [Category("GeoDirections")]
        public void TestGeoDirectionsDefault()
        {
            var pathway = GeoDirections.GetDefaultGeoDirections("Utrecht centraal", "Amersfoort centraal");
        }
    }
}
