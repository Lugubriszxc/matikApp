using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace matikApp.Controllers
{
    public class PageStudentController : Controller
    {

        public IActionResult PageStudentIndex()
        {
            return View();
        }
    }
}