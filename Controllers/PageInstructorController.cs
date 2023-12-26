using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace matikApp.Controllers
{
    public class PageInstructorController : Controller
    {
        public ActionResult PageInstructorIndex(){
            // // Retrieve the ID from the query string
            // if (int.TryParse(Request.Query["id"], out int id))
            // {
            //     // Now you have the ID, and you can use it in your logic
            //     // ...

            //     return View();
            // }
            // else
            // {
            //     // Handle the case where the ID is not present or not a valid integer
            //     return BadRequest("Invalid or missing ID");
            // }
            return View();
        }
    }
}