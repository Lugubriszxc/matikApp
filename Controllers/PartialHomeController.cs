using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace matikApp.Controllers
{
    public class PartialHomeController : Controller
    {
        // private readonly ILogger<PartialHomeController> _logger;

        // public PartialHomeController(ILogger<PartialHomeController> logger)
        // {
        //     _logger = logger;
        // }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
        public ActionResult HomeIndex(){
            return View();
        }

    }
}