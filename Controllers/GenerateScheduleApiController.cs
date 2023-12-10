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

        private List<RoomSchedule> roomSchedule = new List<RoomSchedule>();

        //private List<string> mergedVal = new List<string>();

        private int acadValz = 0;
        private string semesterValz = "";

        public IActionResult startGenerate(int acadVal, string semesterVal)
        {
            getAllData();

            acadValz = acadVal;
            semesterValz = semesterVal;

            algorithmSchedule2();
            return Ok(roomSchedule);
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
                sectionLoop:
                Console.WriteLine("");
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

            int assignSubjectCounter = 0;
            int dump = 0;
            //int filterRoomCounter = 0;

            //bool boolRoomTime = false; //if this becomes true then increment the time

            int sectionCounter = 0;
            var filterSections = Sections.Where(s =>s.CourseId == 39).ToList();

            //Since we received the academic year id and the semester. We are going to add that to the condition

            //check if the section is registered for the academic year and semester
            var resAcadSec = Regissections.Where(rs => rs.AcadYearId == acadValz && rs.Semester == semesterValz).ToList();
            //Console.WriteLine(resAcadSec);

            var resSecJoin = (from sec in Sections
                join rs in resAcadSec on sec.SectionId equals rs.SectionId
                join cor in Courses on sec.CourseId equals cor.CourseId
                //where cor.CourseId == 39

                select new
                {
                    SectionId = sec.SectionId,
                    SectionName = sec.SectionName,
                    YearLevel = sec.YearLevel,
                    DepartmentId = sec.DepartmentId,
                    CourseId = sec.CourseId,
                }).ToList();

            //var filterSections = Sections.Where(s =>s.CourseId == 39 || s.CourseId == 40).ToList();

            //you can replace filterSections with Sections
            foreach(var section in resSecJoin)
            {
                //counting the section;
                sectionCounter++;
                assignSubjectCounter = 0; //starting count

                //filter the assign subject based on section's year level and course id
                var filterAssignsubjects = Assignsubjects.Where(aSub => aSub.YearLevel == section.YearLevel && aSub.CourseId == section.CourseId && aSub.Semester == semesterValz).ToList();
                foreach (var assignSubject in filterAssignsubjects)
                {
                    //replace the 39 with section.courseid and 1st year with section.yearlevel
                    int assignSubjectCount = Assignsubjects.Where(aSub => aSub.CourseId == section.CourseId && aSub.YearLevel == section.YearLevel && aSub.Semester == semesterValz).Count();
                    assignSubjectCounter++;

                    //you can replace this to count all of the sections combined
                    //int sectionCount = Sections.Where(s => s.CourseId == section.CourseId).Count();
                    int sectionCount = Sections.Count(); //December 01, 2023 : switch to this if you want to generate all section's schedule

                    //Console.WriteLine(sectionCounter);

                    //replace the "1st Year" and 39 with section.YearLevel and section.CourseId
                    //remove section.sectionId
                    if(assignSubject.YearLevel == section.YearLevel && assignSubject.CourseId == section.CourseId)
                    {
                        //get the room type
                        var resultSubject = Subjects.Where(sub => sub.SubjectId == assignSubject.SubjectId).FirstOrDefault();
                        //Console.WriteLine(resultSubject.SubjectName);

                        //filter in the instructors who handled the subject and use it for looping
                        var filterIns = Subjecthandleds.Where(x => x.SubjectId == resultSubject.SubjectId).ToList();

                        int instructorCounter = 0;
                        //looped instructor
                        foreach(var instructor in filterIns)
                        {
                            //count the number of instructors who handles the subject
                            int countInstructor = Subjecthandleds.Where(x => x.SubjectId == resultSubject.SubjectId).Count();
                            instructorCounter++;

                            //Get the total units of each teacher based on their handled subjects
                            //MAX UNIT = 24
                            var getSubInstructor = 
                                (from rs in roomSchedule
                                join ins in Instructors on rs.InstructorId equals ins.InstructorId
                                join sub in Subjects on rs.SubjectId equals sub.SubjectId
                                join sec in Sections on rs.SectionId equals sec.SectionId
                                where sub.SubjectId == rs.SubjectId && ins.InstructorId == instructor.InstructorId && sec.SectionId == rs.SectionId
                                select new
                                {
                                    sectionName = sec.SectionName,
                                    instructorN = ins.InstructorFname,
                                    subjectN = sub.SubjectName,
                                    subUnit = sub.SubjectUnit
                                })
                                .Distinct();

                            int totalInstructorUnit = 0;
                            foreach(var result in getSubInstructor)
                            {
                                totalInstructorUnit += result.subUnit;
                            }

                            //CONDITION : if the total unit + the subject unit exceeds, it will find another instructor instead.
                            if(totalInstructorUnit + resultSubject.SubjectUnit > 24)
                            {
                                //CONDITION : if the last instructor reached the limit, it will attempt an overload and bypass the
                                if(instructorCounter != countInstructor)
                                {
                                    //find another instructor instead
                                    goto outInstructorLoop;
                                }
                            }

                            //replace 12 with instructor.InstructorId
                            var resultSubHandle = Subjecthandleds.Where(sh => sh.InstructorId == instructor.InstructorId && sh.SubjectId == resultSubject.SubjectId).FirstOrDefault();
                            if(resultSubHandle != null)
                            {

                                //Here, since we got the room type of the subject we will filter the rooms and loop it.
                                var subName = Subjects.Where(s => s.SubjectId == resultSubHandle.SubjectId).FirstOrDefault();
                                //Console.WriteLine(subName.SubjectName);
                                var filterRoom = Rooms.Where(r => r.RoomType == subName.RoomType).ToList();
                                
                                //count the filteredRoom
                                // loopRoomBack: //loop the room back
                                // int filterRoomCount = filterRoom.Count();
                                // filterRoomCounter = 0;
                                if(filterRoom != null)
                                {
                                    foreach(var fRoom in filterRoom)
                                    {
                                        //filterRoomCounter++;
                                        //don't forget to add a condition to check if the room is available
                                        if(fRoom.RoomCapacity >= 60)
                                        {
                                            //December 10, 2023 : Get the data of the room schedule and filter with the current section and subject. If the last result is Monday then +1
                                            //to get tuesday
                                            //If it's tuesday, then -1 to get monday.
                                            int daySet = 0;
                                            bool setDayCondition = false;

                                            var getLastDay = roomSchedule.Where(rs => rs.SectionId == section.SectionId).LastOrDefault();
                                            // if(getLastDay != null)
                                            // {
                                            //     Console.WriteLine(getLastDay.Day);
                                            //     if(getLastDay.Day == 3 && getLastDay.SubjectId != subName.SubjectId)
                                            //     {
                                            //         daySet = 2;
                                            //         Console.WriteLine(dump++);
                                            //         setDayCondition = true;
                                            //     }
                                            //     else if(getLastDay.Day == 6 && getLastDay.SubjectId != subName.SubjectId)
                                            //     {
                                            //         daySet = 2;
                                            //         Console.WriteLine(dump++);
                                            //         setDayCondition = true;
                                            //     }
                                            // }


                                            //ANOTHER STYLE : randomize a number between 1 to 3
                                            //If 1 then change the day into Tuesday
                                            //If 2 then change the day into Friday
                                            //If 3 then change the day into Monday
                                            if(getLastDay != null)
                                            {
                                                // if(getLastDay.SubjectId != subName.SubjectId)
                                                // {
                                                    
                                                // }
                                                //Randomize it back
                                                randomBack:
                                                // Create a Random object
                                                Random random = new Random();

                                                // Generate a random number between 1 and 3 (inclusive)
                                                int randomNumber = random.Next(1, 4);

                                                int numberOfDays = 0;

                                                switch(randomNumber)
                                                {
                                                    case 1:
                                                        daySet = 2;
                                                        break;
                                                    case 2:
                                                        daySet = 5;
                                                        break;
                                                    case 3:
                                                        daySet = 1;
                                                        break;
                                                }

                                                //call the function that if the number of specific day within that section exceeds or equal to 3 then it will randomize another day
                                                numberOfDays = countDaysMeeting(section.SectionId, daySet);
                                                //countDaysMeeting(section.SectionId, daySet);
                                                Console.WriteLine("Number of days : " + numberOfDays);

                                                int dayCountCondition = 0;
                                                
                                                //If the subject count per section exceeds 9 then the count condition is more than 3. It means the section can meet more than three times
                                                if(assignSubjectCount > 9)
                                                {
                                                    dayCountCondition = 3;
                                                }
                                                else
                                                {
                                                    dayCountCondition = 2;
                                                }

                                                if(numberOfDays > dayCountCondition)
                                                {
                                                    Console.WriteLine("Number of Days within the section : " + section.SectionId + "Days : " + numberOfDays + " Subject ID :" + subName.SubjectId);
                                                    goto randomBack;
                                                }
                                                else
                                                {
                                                    setDayCondition = true;
                                                }
                                            }

                                            //it will loop for 7 days 1 = Monday : 7 = Sunday
                                            for(int day = 1; day <= 7; day++)
                                            {
                                                if(setDayCondition == true)
                                                {
                                                    day = daySet;
                                                    setDayCondition = false;
                                                }

                                                string dayConvert = "";
                                                //Day converter
                                                switch(day)
                                                {
                                                    case 1:
                                                        dayConvert = "Monday";
                                                        break;
                                                    case 2:
                                                        dayConvert = "Tuesday";
                                                        break;
                                                    case 3:
                                                        dayConvert = "Wednesday";
                                                        break;
                                                    case 4:
                                                        dayConvert = "Thursday";
                                                        break;
                                                    case 5:
                                                        dayConvert = "Friday";
                                                        break;
                                                    case 6:
                                                        dayConvert = "Saturday";
                                                        break;
                                                    case 7:
                                                        dayConvert = "Sunday";
                                                        break;
                                                }

                                                //make a condition based on their units
                                                int subjectUnits = subName.SubjectUnit;
                                                int subjectUnitCounter = 0;

                                                // if it's the rotc subject then multiply the subject unit by 2
                                                bool bypassCheck = false;
                                                if(subName.SubjectId == 17)
                                                {
                                                    subjectUnits *= 2;
                                                    //goto byPassROTC;
                                                }

                                                //boolean timeSkipped, if adding the time detected a skip, this becomes true.
                                                bool timeSkipped = false;
                                                bool skipTime = false;
                                                
                                                bool changeInstructor = false;
                                                bool byPassROTC = false;

                                                //sort the time slots first
                                                var sortedTimeslots = Timeslots.OrderBy(ts => ts.StartTime);
                                                int timeCounter = 0;
                                                foreach(var time in sortedTimeslots)
                                                {
                                                    //count how many time slots
                                                    var countTime = Timeslots.OrderBy(ts => ts.StartTime).Count();
                                                    timeCounter++;

                                                    //if the subject id is ROTC, it will skip the conditions here
                                                    if(subName.SubjectId == 17)
                                                    {
                                                        byPassROTC = true;
                                                        goto skipCondition;
                                                    }


                                                    if(roomSchedule.Count != 0)
                                                    {
                                                        //check if the roomschedule with section id and subject id where day != day
                                                        if(subjectUnitCounter >= 1)
                                                        {
                                                            //Found the problem here
                                                            var checkDay = roomSchedule.Where(rs => rs.SectionId == section.SectionId && rs.SubjectId == subName.SubjectId && rs.Day != day).FirstOrDefault();
                                                            if(checkDay != null)
                                                            {
                                                                //check if that day - 2 has a record already in the roomSchedule so it would not be skipped
                                                                var checkRecord = roomSchedule.Where(rs => rs.SectionId == section.SectionId && rs.SubjectId == subName.SubjectId && checkDay.Day-2 != day).FirstOrDefault();
                                                                if(checkRecord != null)
                                                                {
                                                                    if(day != 5)
                                                                    {
                                                                        Console.WriteLine("I was skipped day: " + checkRecord.Day + "Section ID: " + checkRecord.SectionId + "Subject ID: " + checkRecord.SubjectId);
                                                                        timeSkipped = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        //check if there is thursday in friday - 1 in the recorded data
                                                                        var checkDay2 = roomSchedule.Where(rs => rs.SectionId == section.SectionId && rs.SubjectId == subName.SubjectId && rs.Day == day - 1).FirstOrDefault();
                                                                        if(checkDay2 != null)
                                                                        {
                                                                            Console.WriteLine("Hello I was skipped Day: " + checkRecord.Day + "Section ID: " + checkRecord.SectionId + "Subject ID: " + checkRecord.SubjectId);
                                                                            timeSkipped = true;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                    if(time.StartTime == "12:00" && time.EndTime == "13:00")
                                                    {
                                                        timeSkipped = true;
                                                        skipTime = true;
                                                    }

                                                    if(timeSkipped == true)
                                                    {
                                                        eraseList:
                                                        //if time skipped is true then reset the values in list.
                                                        //remove the array where section id, subject id
                                                        roomSchedule.RemoveAll(rs => rs.SectionId == section.SectionId && rs.SubjectId == subName.SubjectId);

                                                        //reset all the counter to 0
                                                        subjectUnitCounter = 0;
                                                        //assignSubjectCounter = 0;

                                                        //make the time skipped false right after
                                                        timeSkipped = false;
                                                        if(skipTime == true)
                                                        {
                                                            skipTime = false;
                                                            goto outTimeLoop;
                                                        }
                                                    }

                                                    if(changeInstructor == true)
                                                    {
                                                        roomSchedule.RemoveAll(rs => rs.SectionId == section.SectionId && rs.SubjectId == subName.SubjectId);
                                                        changeInstructor = false;
                                                        goto outInstructorLoop;
                                                    }

                                                    // //this skips the time and increment it
                                                    // if(boolRoomTime == true)
                                                    // {
                                                    //     goto outTimeLoop;
                                                    // }

                                                    skipCondition:
                                                    //replace 12 with instructor.InstructorId
                                                    var resUnavailablePeriod = Unavailableperiods.Where(up => up.TimeId == time.TimeId && up.Day == dayConvert && up.InstructorId == instructor.InstructorId).FirstOrDefault();
                                                    if(resUnavailablePeriod == null || byPassROTC == true) //null means the instructor is free
                                                    {
                                                        //here, check if the room is available and if the section will not be conflicted with the sched
                                                        var resRoomSched = roomSchedule.Where(rs => rs.RoomId == fRoom.RoomId && rs.TimeId == time.TimeId && rs.Day == day).FirstOrDefault();
                                                        var sectionSched = roomSchedule.Where(rs => rs.TimeId == time.TimeId && rs.SectionId == section.SectionId && rs.Day == day).FirstOrDefault();

                                                        //check if the teacher already has a schedule for teaching
                                                        var instructorSched = roomSchedule.Where(rs => rs.InstructorId == instructor.InstructorId && rs.TimeId == time.TimeId && rs.Day == day).FirstOrDefault();
                                                        if(instructorSched == null || roomSchedule.Count == 0 || byPassROTC == true)
                                                        {
                                                            // add a condition that if the subject id is ROTC then the quadrangle is okay
                                                            //first condition : the section should not be conflicted with the time
                                                            if(sectionSched == null || roomSchedule.Count == 0 || byPassROTC == true)
                                                            {
                                                                bypassCondition:
                                                                //second condition : the room should not be conflicted with the time
                                                                if(resRoomSched == null || roomSchedule.Count == 0 || bypassCheck == true || byPassROTC == true)
                                                                {
                                                                    //return it back to normal
                                                                    bypassCheck = false;
                                                                    byPassROTC = false;
                                                                    //check a condition here if it skips break time
                                                                    //condition : if the subjct id is ROTC and it's not Sunday
                                                                    if(subName.SubjectId == 17 && day != 7) //7 means Sunday
                                                                    {
                                                                        //increment the time until it reaches Saturday
                                                                        goto outTimeLoop;
                                                                    }

                                                                    //jump statement

                                                                    //byPassROTC:
                                                                    //condition : if the subject code is ROTC and it's Sunday
                                                                    if(subName.SubjectId == 17 && day == 7)
                                                                    {
                                                                        roomSchedule.Add(new RoomSchedule(section.SectionId, subName.SubjectId, instructor.InstructorId, fRoom.RoomId, time.TimeId, day));
                                                                        subjectUnitCounter++; //increment the subject unit counter

                                                                        //while the incrementation is not equal, the time will be on a loop to add more time slot based on their units
                                                                        if(subjectUnitCounter != subjectUnits)
                                                                        {
                                                                            goto outTimeLoop;
                                                                        }
                                                                        else
                                                                        {
                                                                            //roomSchedule.Add(new RoomSchedule(section.SectionId, subName.SubjectId, instructor.InstructorId, fRoom.RoomId, time.TimeId));
                                                                            if(assignSubjectCounter + 0 >= assignSubjectCount) //if the assign subject counts go out of bounds
                                                                            {
                                                                                if(sectionCounter + 0 >= sectionCount)
                                                                                {
                                                                                    goto outerLoop;
                                                                                }
                                                                                else
                                                                                {
                                                                                    goto outSectionLoop;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                //increment the assign subject
                                                                                goto outSubjectLoop;
                                                                            }
                                                                        }
                                                                    }

                                                                    //another condition : if the subject id is not ROTC then proceed
                                                                    if(subName.SubjectId != 17)
                                                                    {
                                                                        //if the day is sunday, find another room instead
                                                                        if(day != 7)
                                                                        {
                                                                            roomSchedule.Add(new RoomSchedule(section.SectionId, subName.SubjectId, instructor.InstructorId, fRoom.RoomId, time.TimeId, day));

                                                                            if(day + 2 >= 7)
                                                                            {
                                                                                if(day == 5)
                                                                                {
                                                                                    //LACK OF CONDITIONS : IT MUST CHECK FIRST IF THE INSTRUCTOR IS ALREADY TEACHING OR UNAVAILABLE WITHIN THAT TIME PERIOD BEFORE ADDING THIS TO ROOM SCHEDULE
                                                                                    roomSchedule.Add(new RoomSchedule(section.SectionId, subName.SubjectId, instructor.InstructorId, fRoom.RoomId, time.TimeId, day + 1));
                                                                                }
                                                                            } 
                                                                            else
                                                                            {

                                                                                //LACK OF CONDITIONS : IT MUST CHECK FIRST IF THE INSTRUCTOR IS ALREADY TEACHING OR UNAVAILABLE WITHIN THAT TIME PERIOD BEFORE ADDING THIS TO ROOM SCHEDULE
                                                                                string dayCons = dayConvertFunc(day+2).ToString();
                                                                                Console.WriteLine("DayConvertFunc Section ID : " + section.SectionId + " Subject ID : " + subName.SubjectId + " Instructor : " + instructor.InstructorId + " Day: " + dayCons);
                                                                                var resUnavailablePeriod2 = Unavailableperiods.Where(up => up.TimeId == time.TimeId && up.Day == dayCons && up.InstructorId == instructor.InstructorId).FirstOrDefault();
                                                                                if(resUnavailablePeriod2 == null)
                                                                                {
                                                                                    roomSchedule.Add(new RoomSchedule(section.SectionId, subName.SubjectId, instructor.InstructorId, fRoom.RoomId, time.TimeId, day + 2));
                                                                                }
                                                                                else
                                                                                {
                                                                                    timeSkipped = true;
                                                                                }
                                                                            }

                                                                            subjectUnitCounter++; //increment the subject unit counter

                                                                            //while the incrementation is not equal, the time will be on a loop to add more time slot based on their units
                                                                            if(subjectUnitCounter != subjectUnits)
                                                                            {
                                                                                goto outTimeLoop;
                                                                            }
                                                                            else
                                                                            {
                                                                                //roomSchedule.Add(new RoomSchedule(section.SectionId, subName.SubjectId, instructor.InstructorId, fRoom.RoomId, time.TimeId));
                                                                                if(assignSubjectCounter + 0 >= assignSubjectCount) //if the assign subject counts go out of bounds
                                                                                {
                                                                                    if(sectionCounter + 0 >= sectionCount)
                                                                                    {
                                                                                        goto outerLoop;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        goto outSectionLoop;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    //December 11, 2023 : CONDITION : If the item count of the array is equal to the number of units. Add another set of unit to extend the time
                                                                                    // REASON : The number of items must be x2 from the original total unit of the subject
                                                                                    var countItemUnits = roomSchedule.Where(rs => rs.SectionId == section.SectionId && rs.SubjectId == subName.SubjectId && rs.InstructorId == instructor.InstructorId).ToList();
                                                                                    if(countItemUnits.Count() == subjectUnits)
                                                                                    {
                                                                                        bool foundSaturday = false;
                                                                                        foreach(var item in countItemUnits)
                                                                                        {
                                                                                            if(item.Day == 6)
                                                                                            {
                                                                                                foundSaturday = true;
                                                                                            }
                                                                                        }

                                                                                        if(foundSaturday == true)
                                                                                        {
                                                                                            foundSaturday = false;
                                                                                            //subjectUnits *= 2;

                                                                                            //go back and find another room instead
                                                                                            timeSkipped = true;
                                                                                            goto outRoomLoop;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        //increment the assign subject
                                                                                        goto outSubjectLoop;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            goto outRoomLoop;
                                                                        }
                                        
                                                                    }
                                                                    
                                                                    //boolRoomTime = false;
                                                                    //Console.WriteLine("HELLO THIS IS NEIL");
                                                                    //Console.ReadKey();

                                                                }
                                                                else if(resRoomSched != null)
                                                                {
                                                                    //if the subject is ROTC then bypass the mother if condition
                                                                    if(subName.SubjectId == 17)
                                                                    {
                                                                        bypassCheck = true;
                                                                        goto bypassCondition;
                                                                    }
                                                                    else
                                                                    {
                                                                        //time skipped detected
                                                                        timeSkipped = true;
                                                                    }
                                                                    
                                                                }
                                                            }
                                                            else if(sectionSched != null)
                                                            {
                                                                //time skipped detected
                                                                timeSkipped = true;
                                                            }
                                                        }
                                                        else if(instructorSched != null)
                                                        {
                                                            if(timeCounter == countTime)
                                                            {
                                                                if(instructorCounter + 1 >= countInstructor)
                                                                {
                                                                    timeSkipped = true;
                                                                }
                                                                else
                                                                {
                                                                    changeInstructor = true;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                timeSkipped = true;
                                                            }
                                                        }
                                                        
                                                    }
                                                    else if(resUnavailablePeriod != null)
                                                    {
                                                        //time skipped detected
                                                        timeSkipped = true;
                                                    }
                                                    outTimeLoop:
                                                    Console.Write("");
                                                }

                                                //timeSkipped = true;
                                                //timeSkipped = true;
                                                //end of day loop
                                            }
                                        
                                        }
                                        outRoomLoop:
                                        Console.Write(""); //this is temp
                                    }
                                }
                            }

                            outInstructorLoop:
                            Console.Write("");
                        }
                    }
                    outSubjectLoop:
                    Console.Write(""); //this is just for escape.
                }

                outSectionLoop:
                Console.Write("");
            }

            outerLoop:
            
            if(roomSchedule != null)
            {
                var uniqueRoomSchedules = roomSchedule
                .GroupBy(rs => new { rs.SectionId, rs.SubjectId, rs.InstructorId, rs.RoomId})
                .Select(group => group.First())
                .ToList();

                foreach(var roomSched in uniqueRoomSchedules)
                {
                    var resSection = Sections.Where(sec => sec.SectionId == roomSched.SectionId).FirstOrDefault();
                    var resSubject = Subjects.Where(sub => sub.SubjectId == roomSched.SubjectId).FirstOrDefault();
                    var resInstructor = Instructors.Where(ins => ins.InstructorId == roomSched.InstructorId).FirstOrDefault();
                    var resRoom = Rooms.Where(rom => rom.RoomId == roomSched.RoomId).FirstOrDefault();


                    Console.WriteLine(resSection.SectionName);
                    Console.WriteLine(resSubject.SubjectName);
                    Console.WriteLine(resInstructor.InstructorFname);
                    Console.WriteLine(resRoom.RoomName);

                    //get the day and filter it and loop it
                    var uniqueDayRoomSchedules = roomSchedule
                    .Where(rs =>
                        rs.SectionId == roomSched.SectionId &&
                        rs.SubjectId == roomSched.SubjectId &&
                        rs.InstructorId == roomSched.InstructorId &&
                        rs.RoomId == roomSched.RoomId)
                    .Select(rs => rs.Day)
                    .Distinct()
                    .ToList();

                    // var uniqueDayRoomSchedules = roomSchedule.Where(rs =>
                    //     rs.SectionId == roomSched.SectionId &&
                    //     rs.SubjectId == roomSched.SubjectId &&
                    //     rs.InstructorId == roomSched.InstructorId &&
                    //     rs.RoomId == roomSched.RoomId).Distinct().ToList();

                    string dayConvert = "";
                    foreach(var displayDay in uniqueDayRoomSchedules)
                    {
                        //Day converter
                        switch(displayDay)
                        {
                            case 1:
                                dayConvert = "Monday";
                                break;
                            case 2:
                                dayConvert = "Tuesday";
                                break;
                            case 3:
                                dayConvert = "Wednesday";
                                break;
                            case 4:
                                dayConvert = "Thursday";
                                break;
                            case 5:
                                dayConvert = "Friday";
                                break;
                            case 6:
                                dayConvert = "Saturday";
                                break;
                            case 7:
                                dayConvert = "Sunday";
                                break;
                        }

                        //Console.Write(displayDay);
                        Console.Write(dayConvert + " ");
                    }
                    
                    
                    //convert the looped attributes to get the list of the time
                    var toPrintTime = roomSchedule.Where(rs => rs.InstructorId == roomSched.InstructorId && rs.SectionId == roomSched.SectionId && rs.SubjectId == roomSched.SubjectId && rs.RoomId == roomSched.RoomId).ToList();
                    //printing the time
                    int timeCount = toPrintTime.Count();
                    int timeCounter = 0;
                    foreach(var timePrint in toPrintTime)
                    {
                        timeCounter++;

                        var resTime = Timeslots.Where(ts => ts.TimeId == timePrint.TimeId).FirstOrDefault();
                        //Console.WriteLine(dayConvert + " " + resTime.StartTime + " " + resTime.EndTime);

                        if(timeCounter == 1)
                        {   
                            //only print the first start time
                            Console.Write("\n" + resTime.StartTime);
                        }
                        else if(timeCounter == timeCount)
                        {
                            // if the time counter meets the end
                            Console.Write(" " + resTime.EndTime);
                        }
                    }
                    Console.WriteLine("\n");
                    //Console.ReadKey();
                }

                Console.WriteLine(roomSchedule);


                //Get the total units of each teacher based on their handled subjects
                //MAX UNIT = 24
                var getSubInstructor = 
                    (from rs in roomSchedule
                    join ins in Instructors on rs.InstructorId equals ins.InstructorId
                    join sub in Subjects on rs.SubjectId equals sub.SubjectId
                    join sec in Sections on rs.SectionId equals sec.SectionId
                    where sub.SubjectId == rs.SubjectId && ins.InstructorId == 12 && sec.SectionId == rs.SectionId
                    select new
                    {
                        sectionName = sec.SectionName,
                        instructorN = ins.InstructorFname,
                        subjectN = sub.SubjectName,
                        subUnit = sub.SubjectUnit
                    })
                    .Distinct();

                int totalUnit = 0;
                foreach(var result in getSubInstructor)
                {
                    totalUnit += result.subUnit;
                    Console.WriteLine();
                    Console.WriteLine(result.sectionName);
                    Console.WriteLine(result.instructorN);
                    Console.WriteLine(result.subjectN);
                    Console.WriteLine(result.subUnit);
                }

                Console.WriteLine("Total Unit : " + totalUnit);

            }
            // Console.WriteLine(secName);
            // Console.WriteLine(subjectN);
            // Console.WriteLine(instructorN);
            // Console.WriteLine(roomN);
            // Console.WriteLine(timeN);

            return Ok();
        }

        public string dayConvertFunc(int day)
        {
            string dayConvert = "";
            //Day converter
            switch(day)
            {
                case 1:
                    dayConvert = "Monday";
                    break;
                case 2:
                    dayConvert = "Tuesday";
                    break;
                case 3:
                    dayConvert = "Wednesday";
                    break;
                case 4:
                    dayConvert = "Thursday";
                    break;
                case 5:
                    dayConvert = "Friday";
                    break;
                case 6:
                    dayConvert = "Saturday";
                    break;
                case 7:
                    dayConvert = "Sunday";
                    break;
            }

            return dayConvert;
        } 

        public int countDaysMeeting(int sectionID, int day)
        {
            //var result = roomSchedule.Where(rs => rs.SectionId == sectionID && rs.Day == day).Select(rs => new {rs.Day, rs.SubjectId }).Distinct().ToList();
            var result = roomSchedule.Where(rs => rs.SectionId == sectionID && rs.Day == day).Select(rs => new {rs.SubjectId }).Distinct().ToList();
            if(result != null)
            {
                foreach(var res in result)
                {
                    Console.WriteLine("Section ID: " + sectionID + " Subject ID : " + res.SubjectId + " Day : " + day);
                    Console.WriteLine();
                }
            }
            //var result = roomSchedule.Where(rs => rs.SectionId == sectionID && rs.Day == day).Distinct().Count();
            return result.Count();
            //return result;
        }
    }
}