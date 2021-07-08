using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.BLL.MainFunctions;
using Shared.Entities;
using Shared.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OVRoutePlanner.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Mainpage()
        {
            RouteDTO route = new RouteDTO();
            var datenow = DateTime.Now;
            route.StartingTime = datenow.AddTicks(-(datenow.Ticks % 10000000)).AddSeconds(-datenow.Second);
            route.EndTime = datenow.AddTicks(-(datenow.Ticks % 10000000)).AddSeconds(-datenow.Second);
            route.Date = datenow.AddTicks(-(datenow.Ticks % 10000000)).AddSeconds(-datenow.Second);
            route.Directions = GeoDirections.GetDefaultGeoDirections("Utrecht centraal", "Amersfoort centraal");
            if (route.Directions.Path.Count == 0)
            {
                route.Directions.StartLatitude = "52.091259";
                route.Directions.StartLongitude = "5.122750";
                route.Directions.EndLatitude = "52.156590";
                route.Directions.EndLongitude = "5.388920";
            }
            return View(route);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
         public IActionResult Mainpage(RouteDTO filledInRoute)
         {
            
            Mediator mediator = new Mediator(new RouteDTO(),filledInRoute);
            var route = mediator.ReturnSwappedDTO();


            var calculatefurthestdatedeparture = filledInRoute.StartingTime.Ticks - DateTime.Now.Ticks;
            var calculatefurthestdatearrival = filledInRoute.EndTime.Ticks - DateTime.Now.Ticks;
            if (calculatefurthestdatedeparture < 0)
            {
                calculatefurthestdatedeparture = calculatefurthestdatedeparture * -1;
            }
            if (calculatefurthestdatearrival < 0)
            {
                calculatefurthestdatearrival = calculatefurthestdatearrival * -1;
            }
            if (calculatefurthestdatearrival < calculatefurthestdatedeparture)
            {
                route.StartingTime = filledInRoute.Date.Date + filledInRoute.StartingTime.TimeOfDay;
                var datetimeformatted = route.StartingTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
                route.Directions = GeoDirections.GetGeoDirections(filledInRoute.StartLocation, filledInRoute.EndLocation, arrivaltime: datetimeformatted);
            }
            if (calculatefurthestdatedeparture < calculatefurthestdatearrival)
            {
                route.EndTime = filledInRoute.Date.Date + filledInRoute.EndTime.TimeOfDay;
                var datetimeformatted = route.EndTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
                route.Directions = GeoDirections.GetGeoDirections(filledInRoute.StartLocation, filledInRoute.EndLocation, departuretime: datetimeformatted);
            }
            if (route.Directions.Path.Count == 0)
            {
                route.Directions.StartLatitude = "52.091259";
                route.Directions.StartLongitude = "5.122750";
                route.Directions.EndLatitude = "52.156590";
                route.Directions.EndLongitude = "5.388920";
            }
            return View(route);
         }
    }
}
