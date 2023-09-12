using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace matikApp.Controllers
{
    [Route("[controller]/[action]")]
   // [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DepartmentIndex()
        {
            return View("PartialDepartment/DepartmentIndex");
        }

        public IActionResult CourseIndex()
        {
            return View("PartialCourse/CourseIndex");
        }

        public IActionResult DeanIndex()
        {
            return View("PartialDean/DeanIndex");
        }

        public IActionResult Menu(){
            return View("Widget/Menu");
        }

        public IActionResult InstructorIndex(){
            return View("PartialInstructor/InstructorIndex");
        }

        public IActionResult BuildingIndex(){
            return View("RoomAndBuilding/PartialBuilding/BuildingIndex");
        }

        public IActionResult RoomIndex(){
            return View("RoomAndBuilding/PartialRoom/RoomIndex");
        }
        public IActionResult SubjectIndex(){
            return View("PartialSubjects/SubjectIndex");
        }
        public IActionResult TimeIndex(){
            return View("PartialTime/TimeIndex");
        }

        public IActionResult SectionIndex()
        {
            return View("PartialSection/SectionIndex");
        }

        public IActionResult AssignInstructorIndex()
        {
            return View("PartialAssignInstructor/AssignInstructorIndex");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}