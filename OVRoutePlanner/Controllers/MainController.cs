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
            return View(route);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
         public IActionResult Mainpage(RouteDTO filledInRoute)
         {
            
            Mediator mediator = new Mediator(new RouteDTO(),filledInRoute);
            var route = mediator.ReturnSwappedDTO();
            route.Directions = GeoDirections.GetGeoDirections("Utrecht centraal", "Amersfoort centraal");
            return View(route);
         }
    }
}
