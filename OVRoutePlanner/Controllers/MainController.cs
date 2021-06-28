using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult Mainpage()
        { 
          
        }
    }
}
