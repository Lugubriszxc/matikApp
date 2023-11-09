using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using matikApp.Models;
using matikApp.ViewModel;
using Microsoft.CodeAnalysis.Scripting;

namespace matikApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GenerateScheduleApiController : ControllerBase
    {
        private readonly matikdbContext _context;
        public GenerateScheduleApiController(matikdbContext context)
        {
            _context = context;
        }

        //global lists
        private List<Room> Rooms {get; set;}
        private List<Course> Courses {get; set;}
        private List<Instructor> Instructors {get; set;}
        private List<Unavailableperiod> Unavailableperiods {get; set;}
        private List<Assignsubject> Assignsubjects {get; set;}
        private List<Subject> Subjects {get; set;}
        private List<Subjecthandled> Subjecthandleds {get; set;}
        private List<Section> Sections {get; set;}
        private List<Regissection> Regissections {get; set;}
        private List<Timeslot> Timeslots {get; set;}

        //private List<string> mergedVal = new List<string>();

        public IActionResult startGenerate()
        {
            getAllData();
            algorithmSchedule2();
            return Ok();
        }

        public IActionResult getAllData()
        {
            Rooms = _context.Rooms.ToList();
            Courses = _context.Courses.ToList();
            Instructors = _context.Instructors.ToList();
            Unavailableperiods = _context.Unavailableperiods.ToList();
            Assignsubjects = _context.Assignsubjects.ToList();
            Subjects = _context.Subjects.ToList();
            Subjecthandleds = _context.Subjecthandleds.ToList();
            Sections = _context.Sections.ToList();
            Regissections = _context.Regissections.ToList();
            Timeslots = _context.Timeslots.ToList();

            // mergedVal.AddRange(Rooms.Select(r => r.RoomName));
            // mergedVal.AddRange(Buildings.Select(r => r.BuildingName));
            
            return Ok();
        }

        public IActionResult algorithmSchedule()
        {
            string yearLevel = "";
            int courseId = 0;
            foreach(var section in Sections)
            {
                //get the year level and course id of the first
                yearLevel = section.YearLevel;
                courseId = section.CourseId;

                //select the subjects that is assigned on the course and its year level and loop it out
                // foreach(var assignSubject in Assignsubjects.Select(s => s.YearLevel == yearLevel && s.CourseId == courseId))
                // {
                //     Console.WriteLine(assignSubject.subjectId);
                // }
                //remove this after testing
                if(section.YearLevel == "1st Year" && section.CourseId == 39)
                {
                    //Console.WriteLine(section.SectionName);
                }

                foreach(var assignSubject in Assignsubjects)
                {
                    //replace the "1st Year" and 39 with section.YearLevel and section.CourseId
                    if(assignSubject.YearLevel == section.YearLevel && assignSubject.CourseId == section.CourseId)
                    {
                        //get the room type 
                        var resultSubject = Subjects.Where(sub => sub.SubjectId == assignSubject.SubjectId).FirstOrDefault();

                        //Console.WriteLine(assignSubject.SubjectId);
                        foreach(var time in Timeslots)
                        {
                            //remove this after testing
                            //if(section.YearLevel == "1st Year" && section.CourseId == 39)
                            //{
                                //should we loop the room? or yet make another function?
                                //check the room if there is a time slot registered within the looped.
                                //PLAN : empty list for a room. Register the section, subject and 
                                //time slot if there is available.
                                foreach(var room in Rooms)
                                {
                                    //before room type ; make a condition that if the room is available
                                    //room with time is not registered (the empty list for room)

                                    /*
                                    if(room.RoomType == "Computer Laboratory") // change the computer laboratory with subject's needed room type
                                    {
                                        //check the capacity with the registered section capacity
                                        //PLAN : with the table (regissection)
                                        //get the semester, academic year and the section id
                                        //after that, get the total students to check the capacity
                                        if(room.RoomCapacity >= 60)
                                        {
                                            //Console.WriteLine(room.RoomName);
                                            //Another condition
                                            //looping the instructor and get the instructors with the subject handled
                                            foreach(var instructor in Instructors)
                                            {
                                                //make a condition if the instructor.id instructor unavailable time period. should it be looped or not?
                                                //var timeId = time.TimeId;
                                                var resUnavailablePeriod = Unavailableperiods.Where(up => up.TimeId == time.TimeId && up.InstructorId == instructor.InstructorId).FirstOrDefault();
                                                if(resUnavailablePeriod == null) //null means the instructor is available within that time
                                                {
                                                    //var res;
                                                    var getSubjectHandled = Subjecthandleds.Where(sh => sh.InstructorId == instructor.InstructorId && sh.SubjectId == resultSubject.SubjectId).FirstOrDefault();
                                                    var subName = Subjects.Where(s => s.SubjectId == getSubjectHandled.SubjectId && s.RoomType == "Computer Laboratory").FirstOrDefault();
                                                    if(subName != null)
                                                    {
                                                        Console.WriteLine(subName.SubjectName);
                                                    }
                                                }
                                                //get the instructor id
                                                //with the instructor id, get the subjects handled with subject id
                                                
                                                //var resSubject = _context.Subjecthandleds.Where(sh => sh.InstructorId == instructor.InstructorId && sh.SubjectId == );
                                            }
                                        }
                                        //Console.WriteLine(room.RoomName);
                                    }
                                    */

                                    //looping the instructor and get the instructors with the subject handled
                                    foreach(var instructor in Instructors)
                                    {

                                        var subHandled = Subjecthandleds.Where(sh => sh.InstructorId == 12 && sh.SubjectId == resultSubject.SubjectId).FirstOrDefault();
                                        if(subHandled != null)
                                        {
                                            var subName = Subjects.Where(s => s.SubjectId == subHandled.SubjectId).FirstOrDefault();
                                            if(subName != null)
                                            {
                                                Console.WriteLine(subName.SubjectName);
                                                break;
                                            }
                                        }
                                        //make a condition if the instructor.id instructor unavailable time period. should it be looped or not?
                                        //var timeId = time.TimeId;
                                        /*
                                        var resUnavailablePeriod = Unavailableperiods.Where(up => up.TimeId == time.TimeId && up.InstructorId == instructor.InstructorId).FirstOrDefault();
                                        if(resUnavailablePeriod == null) //null means the instructor is available within that time
                                        {
                                            //var res;
                                            var getSubjectHandled = Subjecthandleds.Where(sh => sh.InstructorId == instructor.InstructorId && sh.SubjectId == resultSubject.SubjectId).FirstOrDefault();
                                            var subName = Subjects.Where(s => s.SubjectId == getSubjectHandled.SubjectId && s.RoomType == "Computer Laboratory").FirstOrDefault();
                                            if(subName != null)
                                            {
                                                Console.WriteLine(subName.SubjectName);
                                            }
                                        }
                                        */
                                        //get the instructor id
                                        //with the instructor id, get the subjects handled with subject id
                                        
                                        //var resSubject = _context.Subjecthandleds.Where(sh => sh.InstructorId == instructor.InstructorId && sh.SubjectId == );
                                    }
                                }

                                //Console.WriteLine(time.Day);
                            //}
                        }
                    }
                }

                //loop the subjects that is only available within the section's year level
                //foreach(var subject in Subjects.Select(r => r.))
            }
            
            return Ok();
        }

        public IActionResult algorithmSchedule2()
        {
            var secName = "";
            var subjectN = "";
            var instructorN = "";
            var roomN = "";
            var timeN = "";

            foreach(var section in Sections)
            {
                foreach (var assignSubject in Assignsubjects)
                {
                    //replace the "1st Year" and 39 with section.YearLevel and section.CourseId
                    //remove section.sectionId
                    if(assignSubject.YearLevel == "1st Year" && assignSubject.CourseId == 39 && section.SectionId == 10)
                    {
                        //get the room type 
                        var resultSubject = Subjects.Where(sub => sub.SubjectId == assignSubject.SubjectId).FirstOrDefault();
                        //Console.WriteLine(resultSubject.SubjectName);

                        //get the subjects handled of every instructor
                        foreach(var instructor in Instructors)
                        {
                            //replace 12 with instructor.InstructorId
                            var resultSubHandle = Subjecthandleds.Where(sh => sh.InstructorId == 12 && sh.SubjectId == resultSubject.SubjectId).FirstOrDefault();
                            if(resultSubHandle != null)
                            {
                                //Here, since we got the room type of the subject we will filter the rooms and loop it.
                                var subName = Subjects.Where(s => s.SubjectId == resultSubHandle.SubjectId).FirstOrDefault();
                                //Console.WriteLine(subName.SubjectName);
                                var filterRoom = Rooms.Where(r => r.RoomType == subName.RoomType).ToList();
                                if(filterRoom != null)
                                {
                                    foreach(var fRoom in filterRoom)
                                    {
                                        //don't forget to add a condition to check if the room is available
                                        //Console.WriteLine(fRoom.RoomName);
                                        if(fRoom.RoomCapacity >= 60)
                                        {
                                            //Console.WriteLine("yawa");
                                            foreach(var time in Timeslots)
                                            {
                                                //replace 12 with instructor.InstructorId
                                                var resUnavailablePeriod = Unavailableperiods.Where(up => up.TimeId == time.TimeId && up.InstructorId == 12).FirstOrDefault();
                                                if(resUnavailablePeriod == null) //null means the instructor is free
                                                {
                                                    //here, check if the room is available
                                                    secName = section.SectionName;
                                                    subjectN = subName.SubjectName;
                                                    instructorN = instructor.InstructorFname;
                                                    roomN = fRoom.RoomName;
                                                    timeN = time.Day + " " + time.StartTime + " " + time.EndTime;
                                                    goto outerLoop;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            outerLoop:
            Console.WriteLine(secName);
            Console.WriteLine(subjectN);
            Console.WriteLine(instructorN);
            Console.WriteLine(roomN);
            Console.WriteLine(timeN);

            return Ok();
        }
    }
}