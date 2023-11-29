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

        public IActionResult startGenerate()
        {
            getAllData();
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
            //int filterRoomCounter = 0;

            //bool boolRoomTime = false; //if this becomes true then increment the time

            int sectionCounter = 0;
            var filterSections = Sections.Where(s =>s.CourseId == 39).ToList();

            //you can replace filterSections with Sections
            foreach(var section in filterSections)
            {
                //counting the section;
                sectionCounter++;
                assignSubjectCounter = 0; //starting count

                //filter the assign subject based on section's year level and course id
                var filterAssignsubjects = Assignsubjects.Where(aSub => aSub.YearLevel == section.YearLevel && aSub.CourseId == section.CourseId).ToList();

                foreach (var assignSubject in filterAssignsubjects)
                {
                    //replace the 39 with section.courseid and 1st year with section.yearlevel
                    int assignSubjectCount = Assignsubjects.Where(aSub => aSub.CourseId == 39 && aSub.YearLevel == section.YearLevel).Count();
                    assignSubjectCounter++;

                    //you can replace this to count all of the sections combined
                    int sectionCount = Sections.Where(s => s.CourseId == 39).Count();
                    Console.WriteLine(sectionCounter);

                    //replace the "1st Year" and 39 with section.YearLevel and section.CourseId
                    //remove section.sectionId
                    if(assignSubject.YearLevel == section.YearLevel && assignSubject.CourseId == 39)
                    {
                        //get the room type
                        var resultSubject = Subjects.Where(sub => sub.SubjectId == assignSubject.SubjectId).FirstOrDefault();
                        //Console.WriteLine(resultSubject.SubjectName);

                        //filter in the instructors who handled the subject and use it for looping
                        var filterIns = Subjecthandleds.Where(x => x.SubjectId == resultSubject.SubjectId).ToList();

                        //looped instructor
                        foreach(var instructor in filterIns)
                        {
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
                                            //it will loop for 7 days 1 = Monday : 7 = Sunday
                                            for(int day = 1; day <= 7; day++)
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

                                                //make a condition based on their units
                                                int subjectUnits = subName.SubjectUnit;
                                                int subjectUnitCounter = 0;

                                                // if it's the rotc subject then multiply the subject unit by 2
                                                if(subName.SubjectId == 17)
                                                {
                                                    subjectUnits *= 2;
                                                }

                                                //boolean timeSkipped, if adding the time detected a skip, this becomes true.
                                                bool timeSkipped = false;
                                                bool skipTime = false;
                                                bool bypassCheck = false;

                                                //sort the time slots first
                                                var sortedTimeslots = Timeslots.OrderBy(ts => ts.StartTime);
                                                foreach(var time in sortedTimeslots)
                                                {
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
                                                                    //if the day is saturday
                                                                    // if(checkRecord.Day == 6)
                                                                    // {
                                                                    //     //Code that will extend the time schedule but within the same time
                                                                    // }
                                                                    // else
                                                                    // {

                                                                    //     timeSkipped = true;
                                                                    // }

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

                                                                    // //check if that day - 1 has a record of more than 1 already in the roomSchedule so it would not be skipped
                                                                    // var checkRecord2 = roomSchedule.Where(rs => rs.SectionId == section.SectionId && rs.SubjectId == subName.SubjectId && checkDay.Day-1 != day).ToList();
                                                                    // if(checkRecord2 != null)
                                                                    // {
                                                                    //     if(checkRecord2.Count() == 1)
                                                                    //     {
                                                                    //         timeSkipped = true;
                                                                    //     }
                                                                    // }
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

                                                    // //this skips the time and increment it
                                                    // if(boolRoomTime == true)
                                                    // {
                                                    //     goto outTimeLoop;
                                                    // }

                                                    //replace 12 with instructor.InstructorId
                                                    var resUnavailablePeriod = Unavailableperiods.Where(up => up.TimeId == time.TimeId && up.Day == dayConvert && up.InstructorId == instructor.InstructorId).FirstOrDefault();
                                                    if(resUnavailablePeriod == null) //null means the instructor is free
                                                    {
                                                        //here, check if the room is available and if the section will not be conflicted with the sched
                                                        var resRoomSched = roomSchedule.Where(rs => rs.RoomId == fRoom.RoomId && rs.TimeId == time.TimeId && rs.Day == day).FirstOrDefault();
                                                        var sectionSched = roomSchedule.Where(rs => rs.TimeId == time.TimeId && rs.SectionId == section.SectionId && rs.Day == day).FirstOrDefault();

                                                        // add a condition that if the subject id is ROTC then the quadrangle is okay
                                                        //first condition : the section should not be conflicted with the time
                                                        if(sectionSched == null || roomSchedule.Count == 0)
                                                        {
                                                            bypassCondition:
                                                            //second condition : the room should not be conflicted with the time
                                                            if(resRoomSched == null || roomSchedule.Count == 0 || bypassCheck == true)
                                                            {
                                                                //return it back to normal
                                                                bypassCheck = false;
                                                                //check a condition here if it skips break time
                                                                //condition : if the subjct id is ROTC and it's not Sunday
                                                                if(subName.SubjectId == 17 && day != 7) //7 means Sunday
                                                                {
                                                                    //increment the time until it reaches Saturday
                                                                    goto outTimeLoop;
                                                                }

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
                                                                                roomSchedule.Add(new RoomSchedule(section.SectionId, subName.SubjectId, instructor.InstructorId, fRoom.RoomId, time.TimeId, day + 1));
                                                                            }
                                                                            //then try + 1 instead
                                                                            // if(day + 1 >= 7)
                                                                            // {
                                                                            //     //Code that continues the schedule in the same day
                                                                            // }
                                                                            // else
                                                                            // {
                                                                            //     roomSchedule.Add(new RoomSchedule(section.SectionId, subName.SubjectId, instructor.InstructorId, fRoom.RoomId, time.TimeId, day + 1));
                                                                            // }
                                                                        } 
                                                                        else
                                                                        {
                                                                            roomSchedule.Add(new RoomSchedule(section.SectionId, subName.SubjectId, instructor.InstructorId, fRoom.RoomId, time.TimeId, day + 2));
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
                                                                                //increment the assign subject
                                                                                goto outSubjectLoop;
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
            }
            // Console.WriteLine(secName);
            // Console.WriteLine(subjectN);
            // Console.WriteLine(instructorN);
            // Console.WriteLine(roomN);
            // Console.WriteLine(timeN);

            return Ok();
        }
    }
}