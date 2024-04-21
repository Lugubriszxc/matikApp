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

        public class SectionClass
        {
            public int SectionID { get; set; }
            public string SectionName { get; set; }
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
                    if (getInstructor != null)
                    {
                        Instructor insGet = new Instructor
                        {
                            InstructorID = getInstructor.InstructorId,
                            InstructorName = getInstructor.InstructorFname + " " + getInstructor.InstructorLname
                        };
                        backlogDetected.Add(insGet);
                    }
                }
            }

            // foreach (var printVal in backlogDetected)
            // {
            //     Console.WriteLine("Instructor doesn't have a schedule detected : " + printVal.InstructorName);
            // }

            return Ok(backlogDetected);
        }

        public IActionResult classBacklogs(int acadVal, string semesterVal)
        {
            List<SectionClass> backlogDetected = new List<SectionClass> { };

            var checkSection = _context.Regissections.Where(s => s.AcadYearId == acadVal && s.Semester == semesterVal).ToList();
            foreach (var sec in checkSection)
            {
                //check the room schedules if there is no sectionID existing
                bool sectionExists = _context.Roomschedules.Any(s => s.SectionId == sec.SectionId && s.AcadYearId == acadVal && s.Semester == semesterVal);

                //If there is a section not existing it means the particular section doesn't have a schedule
                if (!sectionExists)
                {
                    var getSection = _context.Sections.Where(s => s.SectionId == sec.SectionId).FirstOrDefault();
                    if (getSection != null)
                    {
                        SectionClass secGet = new SectionClass
                        {
                            SectionID = getSection.SectionId,
                            SectionName = getSection.SectionName
                        };
                        backlogDetected.Add(secGet);
                    }
                }
            }

            return Ok(backlogDetected);
        }
    }
}