using Newtonsoft.Json;
using Shared.BLL.MainFunctions;
using Shared.Entities;
using Shared.Entities.JSONEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.BLL.SubFunctions
{
    public class Pathway
    {
        public static TransportPathway GenerateDefaultPathWay(TransportPathway pathway, string StartAdress = "Utrecht centraal", string EndAdress = "Amersfoort centraal")
        {

            var client = new WebClient();
            (string latitude, string Langitude) StartCoordinate = GeoCoding.GetLocation(StartAdress);
            (string latitude, string Langitude) EndCoordinate = GeoCoding.GetLocation(EndAdress);
            var text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=" + StartCoordinate.latitude + "," + StartCoordinate.Langitude + "&destination=" + EndCoordinate.latitude + "," + EndCoordinate.Langitude + "&departureTime=2021-07-02T17:00:00");
          
            GeoDirectionsJSONDTO post = JsonConvert.DeserializeObject<GeoDirectionsJSONDTO>(text);
            if (StartCoordinate.Langitude == "0" || StartCoordinate.latitude == "0" || EndCoordinate.Langitude == "0" || EndCoordinate.latitude == "0")
            {
                var defaultinstructions = post.Routes.FirstOrDefault().Sections;
                FillInNodes.FillInNodeData(pathway, defaultinstructions, "Amersfoort centraal");

                (string latitude, string Langitude) StartLocation = GeoCoding.GetLocation("Utrecht centraal");
                (string latitude, string Langitude) EndLocation = GeoCoding.GetLocation("Amersfoort centraal");
                pathway.StartLocation = StartAdress;
                pathway.StartLatitude = StartLocation.latitude;
                pathway.StartLongitude = StartLocation.Langitude;
                pathway.EndLocation = EndAdress;
                pathway.EndLatitude = EndLocation.latitude;
                pathway.EndLongitude = EndLocation.Langitude;
                pathway.ErrorFound = true;
                return pathway;
            }
            var instructions = post.Routes.FirstOrDefault().Sections;
            FillInNodes.FillInDefaultNodes(pathway, instructions, EndAdress);

            pathway.EndLatitude = EndCoordinate.latitude;
            pathway.EndLocation = EndAdress;
            pathway.EndLongitude = EndCoordinate.Langitude;
            pathway.StartLatitude = StartCoordinate.latitude;
            pathway.StartLocation = StartAdress;
            pathway.StartLongitude = StartCoordinate.Langitude;

            return pathway;



        }
        ///
        /// <summary>
        /// Default values for returning default pathway for catching input errors    
        /// </summary>
        /// <param name="pathway"></param>
        /// <param name="StartAdress"></param>
        /// <param name="EndAdress"></param>
        /// <returns></returns>
        /// 
        public static TransportPathway GeneratePathWay(TransportPathway pathway, string StartAdress = "Utrecht centraal", string EndAdress = "Amersfoort centraal",string departuretime = "", string arrivaltime = "")
        {

            var client = new WebClient();
            (string latitude, string Langitude) StartCoordinate = GeoCoding.GetLocation(StartAdress);
            (string latitude, string Langitude) EndCoordinate = GeoCoding.GetLocation(EndAdress);
            string text = "";
            if (departuretime == "" && arrivaltime == "")
            {
                text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=" + StartCoordinate.latitude + "," + StartCoordinate.Langitude + "&destination=" + EndCoordinate.latitude + "," + EndCoordinate.Langitude + "&departureTime=2021-07-02T17:00:00");
            }
            if (departuretime != "")
            {
                text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=" + StartCoordinate.latitude + "," + StartCoordinate.Langitude + "&destination=" + EndCoordinate.latitude + "," + EndCoordinate.Langitude + "&departureTime=" + departuretime);

            }
            if (arrivaltime != "")
            {
                text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=" + StartCoordinate.latitude + "," + StartCoordinate.Langitude + "&destination=" + EndCoordinate.latitude + "," + EndCoordinate.Langitude + "&arrival=" + arrivaltime);

            }
            GeoDirectionsJSONDTO post = JsonConvert.DeserializeObject<GeoDirectionsJSONDTO>(text);
            if (StartCoordinate.Langitude == "0" || StartCoordinate.latitude == "0" || EndCoordinate.Langitude == "0" || EndCoordinate.latitude == "0")
            {
                var defaultinstructions = post.Routes.FirstOrDefault().Sections;
                FillInNodes.FillInNodeData(pathway, defaultinstructions, "Amersfoort centraal");

                (string latitude, string Langitude) StartLocation = GeoCoding.GetLocation("Utrecht centraal");
                (string latitude, string Langitude) EndLocation = GeoCoding.GetLocation("Amersfoort centraal");
                pathway.StartLocation = StartAdress;
                pathway.StartLatitude = StartLocation.latitude;
                pathway.StartLongitude = StartLocation.Langitude;
                pathway.EndLocation = EndAdress;
                pathway.EndLatitude = EndLocation.latitude;
                pathway.EndLongitude = EndLocation.Langitude;
                pathway.ErrorFound = true;
                return pathway;
            }
            var instructions = post.Routes.FirstOrDefault().Sections;
            FillInNodes.FillInNodeData(pathway, instructions, EndAdress);

            pathway.EndLatitude = EndCoordinate.latitude;
            pathway.EndLocation = EndAdress;
            pathway.EndLongitude = EndCoordinate.Langitude;
            pathway.StartLatitude = StartCoordinate.latitude;
            pathway.StartLocation = StartAdress;
            pathway.StartLongitude = StartCoordinate.Langitude;

            return pathway;



        }
    }
}
