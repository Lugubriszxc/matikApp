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
            return View();
        }
    }
}