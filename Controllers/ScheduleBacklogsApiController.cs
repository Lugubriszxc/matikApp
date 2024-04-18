using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using matikApp.Models;

namespace matikApp.Controllers
{
    [Route("api/[controller]/[action]")]

    public class ScheduleBacklogsApiController : ControllerBase
    {
        private readonly matikdbContext _context;

        public ScheduleBacklogsApiController(matikdbContext context)
        {
            _context = context;
        }

        public class Instructor
        {
            public int InstructorID { get; set; }
            public string InstructorName { get; set; }
        }

        public IActionResult instructorBacklogs(int acadVal, string semesterVal)
        {

            List<Instructor> backlogDetected = new List<Instructor> { };

            var checkInstructor = _context.Instructorunitloads.Where(s => s.AcadYearId == acadVal && s.Semester == semesterVal).ToList();
            foreach (var ins in checkInstructor)
            {
                //check the room schedules if there is no instructorID existing
                bool instructorExists = _context.Roomschedules.Any(s => s.InstructorId == ins.InstructorId && s.AcadYearId == acadVal && s.Semester == semesterVal);
                if (!instructorExists)
                {
                    var getInstructor = _context.Instructors.Where(s => s.InstructorId == ins.InstructorId).FirstOrDefault();
                    Console.WriteLine("Instructor doesn't have a schedule detected : " + ins.InstructorId);
                    Instructor insGet = new Instructor
                    {
                        InstructorID = getInstructor.InstructorId,
                        InstructorName = getInstructor.InstructorFname + " " + getInstructor.InstructorLname
                    };
                    backlogDetected.Add(insGet);
                }
            }

            foreach (var printVal in backlogDetected)
            {
                Console.WriteLine("Instructor doesn't have a schedule detected : " + printVal.InstructorName);
            }

            return Ok(backlogDetected);
        }
    }
}