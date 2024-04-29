using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using matikApp.Models;
using NuGet.Protocol.Plugins;

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

        public class InstructorClass
        {
            public int InstructorID { get; set; }
            public string InstructorName { get; set; }
        }

        public class SectionClass
        {
            public int SectionID { get; set; }
            public string SectionName { get; set; }
        }

        public class SubjectSection
        {
            public int SectionID { get; set; }
            public string SectionName { get; set; }
            public string SubjectName { get; set; }
        }

        public class TimeBacklogSection
        {
            public int SectionID { get; set; }
            public string SectionName { get; set; }
            public string SubjectName { get; set; }
        }

        private List<Instructor> Instructors { get; set; }
        private List<Subject> Subjects { get; set; }
        private List<Subjecthandled> Subjecthandleds { get; set; }
        private List<Section> Sections { get; set; }
        private List<Regissection> Regissections { get; set; }
        private List<Roomschedule> Roomschedules { get; set; }
        private List<Room> Rooms {get; set;}
        private List<Instructorunitload> Instructorunitloads { get; set; }
        private List<Assignsubject> Assignsubjects { get; set; }

        public IActionResult getAllData()
        {
            Instructors = _context.Instructors.ToList();
            Subjects = _context.Subjects.ToList();
            Subjecthandleds = _context.Subjecthandleds.ToList();
            Sections = _context.Sections.ToList();
            Regissections = _context.Regissections.ToList();
            Roomschedules = _context.Roomschedules.ToList();
            Rooms = _context.Rooms.ToList();
            Instructorunitloads = _context.Instructorunitloads.ToList();
            Assignsubjects = _context.Assignsubjects.ToList();

            return Ok();
        }

        public IActionResult instructorBacklogs(int acadVal, string semesterVal)
        {
            //Make this as a starting point for getting all the data
            getAllData();
            List<InstructorClass> backlogDetected = new List<InstructorClass> { };

            var checkInstructor = Instructorunitloads.Where(s => s.AcadYearId == acadVal && s.Semester == semesterVal).ToList();
            foreach (var ins in checkInstructor)
            {
                //check the room schedules if there is no instructorID existing
                bool instructorExists = Roomschedules.Any(s => s.InstructorId == ins.InstructorId && s.AcadYearId == acadVal && s.Semester == semesterVal);
                if (!instructorExists)
                {
                    var getInstructor = Instructors.Where(s => s.InstructorId == ins.InstructorId).FirstOrDefault();
                    if (getInstructor != null)
                    {
                        InstructorClass insGet = new InstructorClass
                        {
                            InstructorID = getInstructor.InstructorId,
                            InstructorName = getInstructor.InstructorFname + " " + getInstructor.InstructorLname
                        };
                        backlogDetected.Add(insGet);
                    }
                }
            }

            return Ok(backlogDetected);
        }

        public IActionResult classBacklogs(int acadVal, string semesterVal)
        {
            getAllData();
            List<SectionClass> backlogDetected = new List<SectionClass> { };

            var checkSection = Regissections.Where(s => s.AcadYearId == acadVal && s.Semester == semesterVal).ToList();
            foreach (var sec in checkSection)
            {
                //check the room schedules if there is no sectionID existing
                bool sectionExists = Roomschedules.Any(s => s.SectionId == sec.SectionId && s.AcadYearId == acadVal && s.Semester == semesterVal);

                //If there is a section not existing it means the particular section doesn't have a schedule
                if (!sectionExists)
                {
                    var getSection = Sections.Where(s => s.SectionId == sec.SectionId).FirstOrDefault();
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

        public IActionResult subjectBacklogs(int acadVal, string semesterVal)
        {
            getAllData();
            List<SubjectSection> backlogDetected = new List<SubjectSection> { };

            var checkSection = Regissections.Where(s => s.AcadYearId == acadVal && s.Semester == semesterVal).ToList();

            foreach (var sec in checkSection)
            {
                //get the section detail from regissections 
                var getSec = Sections.Where(s => s.SectionId == sec.SectionId).FirstOrDefault();
                if (getSec != null)
                {
                    //getting the subjects from that section
                    var getAssignSub = Assignsubjects.Where(asub => asub.CourseId == getSec.CourseId && asub.YearLevel == getSec.YearLevel && asub.Semester == semesterVal).ToList();
                    foreach (var subJ in getAssignSub)
                    {
                        bool subjectExists = Roomschedules.Any(rs => rs.SectionId == sec.SectionId && rs.SubjectId == subJ.SubjectId && rs.AcadYearId == acadVal && rs.Semester == semesterVal);
                        if (!subjectExists)
                        {
                            var getSub = Subjects.Where(s => s.SubjectId == subJ.SubjectId).FirstOrDefault();
                            if (getSub != null)
                            {
                                Console.WriteLine("This section : " + getSec.SectionName + "Don't have : " + getSub.SubjectName);
                                SubjectSection subGet = new SubjectSection
                                {
                                    SectionID = getSec.SectionId,
                                    SectionName = getSec.SectionName,
                                    SubjectName = getSub.SubjectName
                                };

                                backlogDetected.Add(subGet);
                            }
                        }
                    }
                }
            }
            return Ok(backlogDetected);
        }



        public IActionResult timeBacklogs(int acadVal, string semesterVal)
        {

            //Get the time schedule that is inaccurate or missing with schedule or end time.
            /*
            DETECTED :
            InstructorID : 26 : Carl Joshua Cosep
            RoomID : 65 : Computer Lab 1
            sectionID : 17 : BSIT - 2C
            SubjectID : 19 : Information Management 1
            Day : 6 : Saturday
            TimeID : 191 : 8:30PM

            ID : 173148
            */

            getAllData();
            List<TimeBacklogSection> backlogDetected = new List<TimeBacklogSection> { };

            var checkSection = Regissections.Where(s => s.AcadYearId == acadVal && s.Semester == semesterVal && s.SectionId == 17).ToList();
            foreach (var sec in checkSection)
            {
                //In every section, filter the subjects
                var getSec = Sections.Where(s => s.SectionId == sec.SectionId).FirstOrDefault();
                if (getSec != null)
                {
                    var getAssignSub = Assignsubjects.Where(asub => asub.CourseId == getSec.CourseId && asub.YearLevel == getSec.YearLevel && asub.Semester == semesterVal).ToList();
                    foreach (var subJ in getAssignSub)
                    {
                        bool subjectExists = Roomschedules.Any(rs => rs.SectionId == sec.SectionId && rs.SubjectId == subJ.SubjectId && rs.AcadYearId == acadVal && rs.Semester == semesterVal);
                        if (subjectExists != null)
                        {
                            //This means to only loop the subject with the room schedules
                            //Get the day count

                            var getSub = Subjects.Where(s => s.SubjectId == subJ.SubjectId).FirstOrDefault();
                            if (getSub != null)
                            {
                                var uniqueDays = Roomschedules
                                .Where(rs => rs.SectionId == sec.SectionId && rs.SubjectId == subJ.SubjectId && rs.AcadYearId == acadVal && rs.Semester == semesterVal)
                                .OrderBy(rs => rs.Day)
                                .Distinct()
                                .ToList();

                                foreach (var detectTime in uniqueDays)
                                {
                                    var countDay = Roomschedules
                                    .Where(rs => rs.SectionId == sec.SectionId && rs.SubjectId == subJ.SubjectId && rs.AcadYearId == acadVal && rs.Semester == semesterVal && rs.Day == detectTime.Day)
                                    .Count();

                                    if (countDay <= 1)
                                    {
                                        TimeBacklogSection secGet = new TimeBacklogSection
                                        {
                                            SectionID = getSec.SectionId,
                                            SectionName = getSec.SectionName,
                                            SubjectName = getSub.SubjectName
                                        };

                                        backlogDetected.Add(secGet);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Ok(backlogDetected);
        }
    }
}