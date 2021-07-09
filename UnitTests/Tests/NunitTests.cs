using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.BLL.MainFunctions;
using Shared.BLL.SubFunctions;
using Shared.Entities;
using System.Net;
using Shared.Entities.JSONEntities;
using Newtonsoft.Json;

namespace UnitTests.Tests
{
    [TestFixture]
    public class NunitTests
    {

        [Test]
        [Category("GeoCoding")]
        public void TestGeoCodingGetLocation()
        {
            var coordinates = GeoCoding.GetLocation("Utrecht centraal");
            Assert.AreNotEqual(0, coordinates.Latitude, "First coordinate is viable");
            Assert.AreNotEqual(0, coordinates.Longitude, "Last coordinate is viable");
        }

        [Test]
        [Category("GeoDirections")]
        public void TestGeoDirectionsDefault()
        {
            var pathway = GeoDirections.GetDefaultGeoDirections("Utrecht centraal", "Amersfoort centraal");
            Assert.Greater(pathway.DefaultPath.Count, 0, "Pathway found");
        }

        [Test]
        [Category("GeoDirections")]
        public void TestGeoDirectionDeparture()
        {
            var pathway = GeoDirections.GetGeoDirections("Utrecht centraal", "Amersfoort centraal", departuretime: DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            Assert.Greater(pathway.Path.Count, 0, "pathway found");
        }

        [Test]
        [Category("GeoDirections")]
        public void TestGeoDirectionArrival()
        {
            var pathway = GeoDirections.GetGeoDirections("Utrecht centraal", "Amersfoort centraal", arrivaltime: DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            Assert.Greater(pathway.Path.Count, 0, "pathway found");
        }

        [Test]
        [Category("PathwayFinding")]
        public void TestDefaultPathway()
        {
            TransportPathway pathwayDTO = new TransportPathway();
            var pathway = Pathway.GenerateDefaultPathWay(pathwayDTO);
            Assert.Greater(pathway.DefaultPath.Count, 0, "pathway found");
        }

        [Test]
        [Category("PathwayFinding")]
        public void TestPathwayDeparture()
        {
            TransportPathway pathwayDTO = new TransportPathway();
            var pathway = Pathway.GeneratePathWay(pathwayDTO, departuretime: DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            Assert.Greater(pathway.Path.Count, 0, "pathway found");
        }

        [Test]
        [Category("PathwayFinding")]
        public void TestPathwayArrival()
        {
            TransportPathway pathwayDTO = new TransportPathway();
            var pathway = Pathway.GeneratePathWay(pathwayDTO, arrivaltime: DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
            Assert.Greater(pathway.Path.Count, 0, "pathway found");
        }

        [Test]
        [Category("FillInNodes")]
        public void TestFillNodeDefault()
        {
            TransportPathway pathway = new TransportPathway();
            var client = new WebClient();
            (string latitude, string Langitude) StartCoordinate = ("52.091259", "5.122750");
            (string latitude, string Langitude) EndCoordinate = ("52.156590", "5.388920");
            var text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=" + StartCoordinate.latitude + "," + StartCoordinate.Langitude + "&destination=" + EndCoordinate.latitude + "," + EndCoordinate.Langitude + "&departureTime=" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));

            GeoDirectionsJSONDTO post = JsonConvert.DeserializeObject<GeoDirectionsJSONDTO>(text);
            var instructions = post.Routes.FirstOrDefault().Sections;
            FillInNodes.FillInDefaultNodes(pathway, instructions, "Amersfoort centraal");

            Assert.Greater(pathway.DefaultPath.Count, 0, "pathway found");
        }

        [Test]
        [Category("FillInNodes")]
        public void TestFillNodeDeparture()
        {
            TransportPathway pathway = new TransportPathway();
            var client = new WebClient();
            (string latitude, string Langitude) StartCoordinate = ("52.091259", "5.122750");
            (string latitude, string Langitude) EndCoordinate = ("52.156590", "5.388920");
            var text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=" + StartCoordinate.latitude + "," + StartCoordinate.Langitude + "&destination=" + EndCoordinate.latitude + "," + EndCoordinate.Langitude + "&departureTime=" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));

            GeoDirectionsJSONDTO post = JsonConvert.DeserializeObject<GeoDirectionsJSONDTO>(text);
            var instructions = post.Routes.FirstOrDefault().Sections;
            FillInNodes.FillInNodeData(pathway, instructions, "Amersfoort centraal");

            Assert.Greater(pathway.Path.Count, 0, "pathway found");
        }

        [Test]
        [Category("FillInNodes")]
        public void TestFillNodeArrival()
        {
            TransportPathway pathway = new TransportPathway();
            var client = new WebClient();
            (string latitude, string Langitude) StartCoordinate = ("52.091259", "5.122750");
            (string latitude, string Langitude) EndCoordinate = ("52.156590", "5.388920");
            var text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=" + StartCoordinate.latitude + "," + StartCoordinate.Langitude + "&destination=" + EndCoordinate.latitude + "," + EndCoordinate.Langitude + "&arrival=" + DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));

            GeoDirectionsJSONDTO post = JsonConvert.DeserializeObject<GeoDirectionsJSONDTO>(text);
            var instructions = post.Routes.FirstOrDefault().Sections;
            FillInNodes.FillInNodeData(pathway, instructions, "Amersfoort centraal");

            Assert.Greater(pathway.Path.Count, 0, "pathway found");
        }
    }
}
