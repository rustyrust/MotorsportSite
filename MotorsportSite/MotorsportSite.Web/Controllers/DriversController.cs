using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MotorsportSite.Web.Controllers
{
    public class DriversController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}