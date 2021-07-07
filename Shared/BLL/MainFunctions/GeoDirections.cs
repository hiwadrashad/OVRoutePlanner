using Shared.BLL.SubFunctions;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.BLL.MainFunctions
{
    public class GeoDirections
    {
        public static TransportPathway GetDefaultGeoDirections(string StartAdress, string EndAdress)
        {
            TransportPathway pathway = new TransportPathway();
            var client = new WebClient();
            (string latitude, string Langitude) StartCoordinate = GeoCoding.GetLocation(StartAdress);
            (string latitude, string Langitude) EndCoordinate = GeoCoding.GetLocation(EndAdress);
            if (StartCoordinate.Langitude == "0" || StartCoordinate.latitude == "0" || EndCoordinate.Langitude == "0" || EndCoordinate.latitude == "0")
            {

                pathway.ErrorFound = true;
                return pathway;
            }
            try
            {
                var filledinpathway = Pathway.GenerateDefaultPathWay(pathway, StartAdress, EndAdress);
                foreach (var item in filledinpathway.Path)
                {
                    Console.WriteLine(item.PlaceAndTime);
                    Console.WriteLine(item.TransportData);
                    Console.WriteLine("");
                }
                Console.WriteLine(filledinpathway.EndLatitude);
                return filledinpathway;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException nullex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Incorrect value given");
                TransportPathway pathwayNullReferenceEx = new TransportPathway();
                pathwayNullReferenceEx.ErrorFound = true;
                return pathwayNullReferenceEx;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (WebException webex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Incorrect value given");
                TransportPathway pathwayWebEx = new TransportPathway();
                pathwayWebEx.ErrorFound = true;
                return pathwayWebEx;
            }

#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Something went wrong");
                TransportPathway pathwayGenEx = new TransportPathway();
                pathwayGenEx.ErrorFound = true;
                return pathwayGenEx;
            }
        }
        public static TransportPathway GetGeoDirections(string StartAdress, string EndAdress, string departuretime = "", string arrivaltime = "")
        {
            TransportPathway pathway = new TransportPathway();
            var client = new WebClient();
            (string latitude, string Langitude) StartCoordinate = GeoCoding.GetLocation(StartAdress);
            (string latitude, string Langitude) EndCoordinate = GeoCoding.GetLocation(EndAdress);
            if (StartCoordinate.Langitude == "0" || StartCoordinate.latitude == "0" || EndCoordinate.Langitude == "0" || EndCoordinate.latitude == "0")
            {

                pathway.ErrorFound = true;
                return pathway;
            }
            try
            {
                TransportPathway filledinpathway = new TransportPathway();
                if (departuretime == "" & arrivaltime == "")
                {
                    filledinpathway = Pathway.GeneratePathWay(pathway, StartAdress, EndAdress);
                }
                if (departuretime != "")
                {
                    filledinpathway = Pathway.GeneratePathWay(pathway, StartAdress, EndAdress, departuretime: departuretime);
                }
                if (arrivaltime != "")
                {
                    filledinpathway = Pathway.GeneratePathWay(pathway, StartAdress, EndAdress, arrivaltime: arrivaltime);
                }
                foreach (var item in filledinpathway.Path)
                {
                    Console.WriteLine(item.PlaceAndTime);
                    Console.WriteLine(item.TransportData);
                    Console.WriteLine("");
                }
                Console.WriteLine(filledinpathway.EndLatitude);
                return filledinpathway;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException nullex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Incorrect value given");
                TransportPathway pathwayNullReferenceEx = new TransportPathway();
                pathwayNullReferenceEx.ErrorFound = true;
                return pathwayNullReferenceEx;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (WebException webex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Incorrect value given");
                TransportPathway pathwayWebEx = new TransportPathway();
                pathwayWebEx.ErrorFound = true;
                return pathwayWebEx;
            }

#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Something went wrong");
                TransportPathway pathwayGenEx = new TransportPathway();
                pathwayGenEx.ErrorFound = true;
                return pathwayGenEx;
            }
        }
    }
}
