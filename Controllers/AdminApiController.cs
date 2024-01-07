using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using matikApp.Models;
using matikApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace matikApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AdminApiController : ControllerBase
    {
        private readonly matikdbContext _context;
        public AdminApiController(matikdbContext context)
        {
            _context = context;
        }

        //Department Section
        public IActionResult createDepartment(Department dep)
        {

            var res = _context.Departments.Where(x => x.DepartmentName == dep.DepartmentName).FirstOrDefault();
            if(res == null)
            {
                _context.Departments.Add(dep);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return Ok(res);
            }
        }

        public ActionResult<List<Department>> getDepartment(){
            return  _context.Departments.ToList();
        }

        public IActionResult updateDepartment(Department dep)
        {
            _context.Departments.Update(dep);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult deleteDepartment(int departmentId)
        {
            var res = _context.Departments.Where(element => element.DepartmentId == departmentId).FirstOrDefault();
            _context.Departments.Remove(res);
            _context.SaveChanges();
            return Ok();
        }

       //Course Section API
        public IActionResult createCourse(Course cor)
        {
            var res = _context.Courses.Where(x => x.CourseName == cor.CourseName && x.DepartmentId == cor.DepartmentId).FirstOrDefault();
            if(res == null)
            {
                _context.Courses.Add(cor);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return Ok(res);
            }
            
        }

        public IActionResult getCourseDep()
        {
            var res = 
            (
                from d in _context.Departments
                join c in _context.Courses
                on d.DepartmentId equals c.DepartmentId

                select new CorDep
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                    CourseId = c.CourseId,
                    CourseName = c.CourseName
                }
            ).ToList();

            return Ok(res);
        }

        public ActionResult<List<Course>> getCourse(){
            return  _context.Courses.ToList();
        }

        public IActionResult updateCourse(Course cor)
        {
            _context.Courses.Update(cor);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult deleteCourse(int courseId)
        {
            var res = _context.Courses.Where(element => element.CourseId == courseId).FirstOrDefault();
            _context.Courses.Remove(res);
            _context.SaveChanges();
            return Ok();
        }

        //Dean Section API
        public IActionResult getDeanDep()
        {
            //var res = new List<DeanDep>{};
            var res = new object();

            //applying a try catch to return an empty string instead of null
            try{
                res = 
                (
                from d in _context.Departments
                join den in _context.Deans
                on d.DepartmentId equals den.DepartmentId
                
                select new DeanDep
                {
                    DeanId = den.DeanId,
                    DeanFname = den.DeanFname,
                    DeanMname = den.DeanMname,
                    DeanLname = den.DeanLname,
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                }
                ).ToList();
            }catch{
                res = 
                (
                from d in _context.Departments
                join den in _context.Deans
                on d.DepartmentId equals den.DepartmentId

                select new DeanDep
                {
                    DeanId = den.DeanId,
                    DeanFname = den.DeanFname,
                    DeanMname = " ",
                    DeanLname = den.DeanLname,
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                }
                ).ToList();
            }

            return Ok(res);
        }

        //query to create a dean
        public IActionResult createDean(Dean den)
        {
            if(den.DeanMname == null)
            {
                den.DeanMname = "";
            }
            _context.Deans.Add(den);
            _context.SaveChanges();

            return Ok();
        }

        //query to return true or false if the department has already a dean.
        public IActionResult checkDeanDep(int depID)
        {
            bool isDepDeanRegistered = false;

            //if the row has already the departmentID then this will return true
            var res = _context.Deans.Where(element => element.DepartmentId == depID).FirstOrDefault();
            if(res == null)
            {isDepDeanRegistered = false;}
            else{isDepDeanRegistered = true;}
            
            return Ok(isDepDeanRegistered);
        }

        //query to delete the selected dean
        public IActionResult deleteDean(int deanId)
        {
            _context.Deans.Remove(_context.Deans.Find(deanId));
            _context.SaveChanges();

            //_context.Database.ExecuteSqlRaw(deletecommand);

            return Ok();
        }

        //query to fetch the dean list
        public ActionResult<List<Dean>> getDeans(){
            return  _context.Deans.ToList();
        }

        //query to update the dean
        public IActionResult updateDean(Dean den)
        {
            if(den.DeanMname == null)
            {
                den.DeanMname = "";
            }
            _context.Deans.Update(den);
            _context.SaveChanges();
            return Ok();
        }

        //Instructor Section API
        public IActionResult getInstructorDep()
        {
            //var res = new List<DeanDep>{};
            var res = new object();

            //applying a try catch to return an empty string instead of null
            try{
                res = 
                (
                from d in _context.Departments
                join i in _context.Instructors on d.DepartmentId equals i.DepartmentId
                // join up in _context.Unavailableperiods on i.InstructorId equals up.InstructorId
                // join ts in _context.Timeslots on up.TimeId equals ts.TimeId
                
                select new InstructorDep
                {
                    InstructorId = i.InstructorId,
                    InstructorFname = i.InstructorFname,
                    InstructorMname = i.InstructorMname,
                    InstructorLname = i.InstructorLname,
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                }
                ).ToList();
            }catch{
                res = 
                (
                from d in _context.Departments
                join i in _context.Instructors on d.DepartmentId equals i.DepartmentId
                // join up in _context.Unavailableperiods on i.InstructorId equals up.InstructorId
                // join ts in _context.Timeslots on up.TimeId equals ts.TimeId

                select new InstructorDep
                {
                    InstructorId = i.InstructorId,
                    InstructorFname = i.InstructorFname,
                    InstructorMname = " ",
                    InstructorLname = i.InstructorLname,
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                }
                ).ToList();
            }

            return Ok(res);
        }

        public IActionResult getUnavailableTimePeriod(int instructorId)
        {
            var res = 
                (
                from i in _context.Instructors
                join up in _context.Unavailableperiods on i.InstructorId equals up.InstructorId
                join ts in _context.Timeslots on up.TimeId equals ts.TimeId
                where i.InstructorId == instructorId
                
                select new InstructorTime
                {
                    UaId = up.UaId,
                    InstructorId = i.InstructorId,
                    TimeId = ts.TimeId,
                    Day = up.Day,
                    StartTime = ts.StartTime,
                    EndTime = ts.EndTime
                }
                ).ToList();

            return Ok(res);
        }

        //to fetch the subjects handled of the instructor
        public IActionResult getSubjectHandlePeriod(int instructorId)
        {
            var res = 
                (
                from i in _context.Instructors
                join sh in _context.Subjecthandleds on i.InstructorId equals sh.InstructorId
                join s in _context.Subjects on sh.SubjectId equals s.SubjectId
                where i.InstructorId == instructorId
                
                select new InstructorSubject
                {
                    ShId = sh.ShId,
                    InstructorId = i.InstructorId,
                    InstructorFname = i.InstructorFname,
                    InstructorMname = i.InstructorMname,
                    InstructorLname = i.InstructorLname,
                    SubjectId = s.SubjectId,
                    SubjectCode = s.SubjectCode,
                    SubjectName = s.SubjectName,
                    SubjectUnit = s.SubjectUnit                    
                }
                ).ToList();

            return Ok(res);
        }

        //query to fetch the instructor list
        public ActionResult<List<Instructor>> getInstructors(){
            return  _context.Instructors.ToList();
        }

        //query to create an instructor
        public IActionResult createInstructor(Instructor i)
        {
            if(i.InstructorMname == null)
            {
                i.InstructorMname = "";
            }
            _context.Instructors.Add(i);
            _context.SaveChanges();
            makeDynamicAccountInstructor();
            return Ok();
        }

        public IActionResult checkEmailInstructor(Instructor i)
        {
            //If there is email address found
            var res = _context.Instructors.Where(e => e.EmailAddress == i.EmailAddress).FirstOrDefault();
            if(res == null)
            {   
                return Ok();
            }
            else
            {
                //check if it's because of the selected instructor
                if(res.InstructorId == i.InstructorId)
                {
                    return Ok();
                }
                else
                {
                    return Ok(res);
                }
            }
        }

        public IActionResult makeDynamicAccountInstructor()
        {
            //Console.WriteLine("I was called");
            var instructor = _context.Instructors.ToList();
            foreach(var ins in instructor)
            {
                var checkRes = _context.Authorizations.Where(cs => cs.UserType == "instructor" && cs.Id == ins.InstructorId).FirstOrDefault();
                if(checkRes == null)
                {
                    //if it's empty result, then free to add the account
                    var auth = new Authorization
                    {
                        Username = ins.InstructorId.ToString(),
                        Password = ins.InstructorId.ToString(),
                        UserType = "instructor",
                        Id = ins.InstructorId,
                    };

                    _context.Authorizations.Add(auth);
                    _context.SaveChanges();
                }
            }
            return Ok();
        }

        public IActionResult makeDynamicAccountStudent()
        {
            var student = _context.Studentprofiles.ToList();
            foreach(var stud in student)
            {
                var checkRes = _context.Authorizations.Where(cs => cs.UserType == "student" && cs.Id == stud.StudentId).FirstOrDefault();
                if(checkRes == null)
                {
                    //if it's empty result, then free to add the account
                    var auth = new Authorization
                    {
                        Username = stud.SchoolId.ToString(),
                        Password = stud.SchoolId.ToString(),
                        UserType = "student",
                        Id = stud.StudentId,
                    };

                    _context.Authorizations.Add(auth);
                    _context.SaveChanges();
                }
            }
            return Ok();
        }

        //query to delete the selected instructor
        public IActionResult deleteInstructor(int instructorId)
        {
            _context.Instructors.Remove(_context.Instructors.Find(instructorId));

            var res = _context.Unavailableperiods.Where(e => e.InstructorId == instructorId).ToList();
            var res2 = _context.Instructorunitloads.Where(e => e.InstructorId == instructorId).ToList();
            var res3 = _context.Subjecthandleds.Where(e => e.InstructorId == instructorId).ToList();
            var resAuth = _context.Authorizations.Where(e => e.Id == instructorId && e.UserType == "instructor").FirstOrDefault();

            _context.Authorizations.Remove(resAuth);
            _context.Unavailableperiods.RemoveRange(res);
            _context.Instructorunitloads.RemoveRange(res2);
            _context.Subjecthandleds.RemoveRange(res3);

            _context.SaveChanges();

            //_context.Database.ExecuteSqlRaw(deletecommand);

            return Ok();
        }

        //query to update the instructor
        public IActionResult updateInstructor(Instructor i)
        {
            if(i.InstructorMname == null)
            {
                i.InstructorMname = "";
            }
            _context.Instructors.Update(i);
            _context.SaveChanges();
            return Ok();
        }

        //Building Section API
        //query to fetch the building list
        public ActionResult<List<Building>> getBuildings(){
            return  _context.Buildings.ToList();
        }

        //query to create a building
        public IActionResult createBuilding(Building bld)
        {
            if(bld.BuildingName == null)
            {
                return Ok("Error Occured");
            }
            _context.Buildings.Add(bld);
            _context.SaveChanges();

            return Ok();
        }

        //query to delete the selected building
        public IActionResult deleteBuilding(int buildingId)
        {
            _context.Buildings.Remove(_context.Buildings.Find(buildingId));
            _context.SaveChanges();
            return Ok();
        }

        //query to update the building
        public IActionResult updateBuilding(Building bld)
        {
            if(bld.BuildingName == null)
            {
                return Ok("Error Occured");
            }
            _context.Buildings.Update(bld);
            _context.SaveChanges();
            return Ok();
        }


        //Room Section API
        
        //joins the room and building
        public IActionResult getRoomAndBuilding()
        {
            var res = new object();

            //applying a try catch to return an empty string instead of null
            try{
                res = 
                (
                from r in _context.Rooms
                join b in _context.Buildings
                on r.BuildingId equals b.BuildingId
                
                select new RoomBuild
                {
                    RoomId = r.RoomId,
                    RoomName = r.RoomName,
                    RoomType = r.RoomType,
                    RoomCapacity = r.RoomCapacity,
                    BuildingId = b.BuildingId,
                    BuildingName = b.BuildingName,
                }
                ).ToList();
            }catch{
                res = 
                (
                from r in _context.Rooms
                join b in _context.Buildings
                on r.BuildingId equals b.BuildingId

                select new RoomBuild
                {
                    RoomId = r.RoomId,
                    RoomName = r.RoomName,
                    RoomType = r.RoomType,
                    RoomCapacity = r.RoomCapacity,
                    BuildingId = 0,
                    BuildingName = " ",
                }
                ).ToList();
            }

            return Ok(res);
        }

        //query to fetch the room list
        public ActionResult<List<Room>> getRooms(){
            return  _context.Rooms.ToList();
        }
        
        //query to create a room
        public IActionResult createRoom(Room rm)
        {
            if(rm == null)
            {
                return Ok("Error Occurred");
            }
            _context.Rooms.Add(rm);
            _context.SaveChanges();

            return Ok();
        }

        //query to delete the selected room
        public IActionResult deleteRoom(int roomId)
        {
            _context.Rooms.Remove(_context.Rooms.Find(roomId));
            _context.SaveChanges();
            return Ok();
        }

        //query to update the room
        public IActionResult updateRoom(Room rm)
        {
            if(rm == null)
            {
                return Ok("Error Occured");
            }
            
            _context.Rooms.Update(rm);
            _context.SaveChanges();
            return Ok();
        }

        //Subject Section API
        //query to fetch the subject list
        public ActionResult<List<Subject>> getSubjects(){
            return  _context.Subjects.ToList();
        }

        //filter the subject list
        public IActionResult filterSubjectList(string searchedItem)
        {
            searchedItem = searchedItem.ToLower();
            var searchedSubject = _context.Subjects.Where(e => e.SubjectName.ToLower().Contains(searchedItem) || e.SubjectCode.ToLower().Contains(searchedItem));
            return Ok(searchedSubject);
        }

        //query to create a room
        public IActionResult createSubject(Subject sub)
        {
            if(sub == null)
            {
                return Ok("Error Occurred");
            }
            _context.Subjects.Add(sub);
            _context.SaveChanges();

            return Ok();
        }

        //query to delete the selected subject
        public IActionResult deleteSubject(int subjectId)
        {
            _context.Subjects.Remove(_context.Subjects.Find(subjectId));
            _context.SaveChanges();
            return Ok();
        }

        //query to update the room
        public IActionResult updateSubject(Subject sub)
        {
            if(sub == null)
            {
                return Ok("Error Occured");
            }
            
            _context.Subjects.Update(sub);
            _context.SaveChanges();
            return Ok();
        }

        //Time Slot Section API
        //query to fetch the time list
        public ActionResult<List<Timeslot>> getTimeSlots(){
            return  _context.Timeslots.ToList();
        }

        //query to create a Time slot
        public IActionResult createTimeSlot(Timeslot ts)
        {
            if(ts == null)
            {
                return Ok("Error Occurred");
            }

            var res = _context.Timeslots.Where(x => x.StartTime == ts.StartTime && x.EndTime == ts.EndTime).FirstOrDefault();
            if(res == null)
            {
                _context.Timeslots.Add(ts);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return Ok(res);
            }
        }

        //query to delete the selected time slot
        public IActionResult deleteTimeSlot(int timeId)
        {
            _context.Timeslots.Remove(_context.Timeslots.Find(timeId));
            _context.SaveChanges();
            return Ok();
        }

        //query to update the time slot
        public IActionResult updateTimeSlot(Timeslot ts)
        {
            if(ts == null)
            {
                return Ok("Error Occured");
            }
            
            _context.Timeslots.Update(ts);
            _context.SaveChanges();
            return Ok();
        }

        //query to create an unavailable time slot
        public ActionResult<List<Unavailableperiod>> getUnavailableperiods(){
            return  _context.Unavailableperiods.ToList();
        }

        public IActionResult createUnavailablePeriod(Unavailableperiod up)
        {
            if(up.InstructorId == 0 || up.InstructorId == null)
            {
                return Ok("Error Occurred");
            }

            var res = _context.Unavailableperiods.Where(x => x.Day == up.Day && x.TimeId == up.TimeId).FirstOrDefault();
            if(res == null)
            {
                _context.Unavailableperiods.Add(up);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return Ok(res);
            }
        }

        //fetch subject handleds
        public ActionResult<List<Subjecthandled>> getSubjecthandleds(){
            return  _context.Subjecthandleds.ToList();
        }

        //query to create subject handled
        public IActionResult addSubjectHandled(Subjecthandled sh)
        {
            if(sh.InstructorId == 0 || sh.InstructorId == null || sh.SubjectId == 0 || sh.SubjectId == null)
            {
                return Ok("Error Occurred");
            }

            var res = _context.Subjecthandleds.Where(x => x.SubjectId == sh.SubjectId && x.InstructorId == sh.InstructorId).FirstOrDefault();
            if(res == null)
            {
                _context.Subjecthandleds.Add(sh);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return Ok(res);
            }
        }

        //check if there is any existing data for subject handled
        public IActionResult checkSubjectHandled(Subjecthandled sh)
        {
            var res = _context.Subjecthandleds.Where(x => x.SubjectId == sh.SubjectId && x.InstructorId == sh.InstructorId).FirstOrDefault();
            return Ok(res);
        }

        //query to delete an unavailable time slot
        public IActionResult deleteUATime(int uaId)
        {
            _context.Unavailableperiods.Remove(_context.Unavailableperiods.Find(uaId));
            _context.SaveChanges();
            return Ok();
        }

        //query to delete a subject handled
        public IActionResult deleteSubjectHandled(int shId)
        {
            _context.Subjecthandleds.Remove(_context.Subjecthandleds.Find(shId));
            _context.SaveChanges();
            return Ok();
        }

        //Class/Section API
        //query to fetch the section list
        public ActionResult<List<Section>> getSections(){
            return  _context.Sections.ToList();
        }

        //query to fetch the section, department and course (inner join)
        public IActionResult getSecDepCor()
        {
            try
            {
                var res = 
                    (
                    from sec in _context.Sections
                    join dep in _context.Departments on sec.DepartmentId equals dep.DepartmentId
                    join cor in _context.Courses on sec.CourseId equals cor.CourseId
                    
                    select new SecDepCor
                    {
                        SectionId = sec.SectionId,
                        SectionName = sec.SectionName,
                        YearLevel = sec.YearLevel,
                        DepartmentId = dep.DepartmentId,
                        CourseId = cor.CourseId,
                        DepartmentName = dep.DepartmentName,
                        CourseName = cor.CourseName,
                    }

                ).ToList();

                return Ok(res);
            }
            catch
            {
                return Ok("Entity not found.");
            }
        }

        //fetch multiple courses with matching department id
        public ActionResult<List<Course>> getCourseSelectDep(int departmentId){
            return  _context.Courses.Where(e => e.DepartmentId == departmentId).ToList();
        }

        public IActionResult getSectionSelect(int courseId, string yearLevel, int acadVal, string semVal){

            try
            {
                var res = 
                    (
                    from regis in _context.Regissections
                    join sec in _context.Sections on regis.SectionId equals sec.SectionId
                    where regis.AcadYearId == acadVal && regis.Semester == semVal && sec.CourseId == courseId && sec.YearLevel == yearLevel
                    
                    select new SecRegisPopulate
                    {
                        SectionId = sec.SectionId,
                        SectionName = sec.SectionName,
                        YearLevel = sec.YearLevel,
                        DepartmentId = sec.DepartmentId,
                        CourseId = sec.CourseId,                    
                    }

                ).ToList();

                return Ok(res);
            }
            catch
            {
                return Ok("Entity not found.");
            }
            //return  _context.Sections.Where(e => e.CourseId == courseId && e.YearLevel == yearLevel).ToList();
        }

        //fetch multiple instructors with matching department id
        public ActionResult<List<Instructor>> getInstructorSelectDep(int departmentId){
            return  _context.Instructors.Where(e => e.DepartmentId == departmentId).ToList();
        }

        //query to create a Time slot
        public IActionResult createSection(Section sec)
        {
            if(sec == null)
            {
                return Ok("Error Occurred");
            }

            _context.Sections.Add(sec);
            _context.SaveChanges();

            return Ok();
        }

        //query to delete an section
        public IActionResult deleteSection(int sectionId)
        {
            //delete the connected value of section id
            var resStudEnroll = _context.Studentenrollments.Where(e => e.SectionId == sectionId).ToList();
            var resRegisSection = _context.Regissections.Where(e => e.SectionId == sectionId).ToList();

            _context.Studentenrollments.RemoveRange(resStudEnroll);
            _context.Regissections.RemoveRange(resRegisSection);
            _context.Sections.Remove(_context.Sections.Find(sectionId));
            _context.SaveChanges();
            return Ok();
        }

        //query to update the section
        public IActionResult updateSection(Section sec)
        {
            if(sec == null)
            {
                return Ok("Error Occured");
            }
            
            _context.Sections.Update(sec);
            _context.SaveChanges();
            return Ok();
        }

        //Assign Instructor API
        //fetch multiple section with matching year level and course id
        public ActionResult<List<Section>> getSectionYearrCor(string yearLevel, int courseId){
            //return  _context.Courses.Where(e => e.DepartmentId == departmentId).ToList();
            return _context.Sections.Where(e => e.YearLevel == yearLevel && e.CourseId == courseId).ToList();
        }

        public ActionResult<List<Assignsubject>> getAssignsubjects(){
            return  _context.Assignsubjects.ToList();
        }

        //query to assign an instructor
        public IActionResult createAssignInstructor(Assignsubject asi)
        {
            if(asi == null)
            {
                return Ok("Error Occured");
            }
            _context.Assignsubjects.Add(asi);
            _context.SaveChanges();

            return Ok();
        }

        //query to update an assigned instructor and subject
        public IActionResult updateAssignInstructor(Assignsubject asi)
        {
            if(asi == null)
            {
                return Ok("Error Occured");
            }
            
            _context.Assignsubjects.Update(asi);
            _context.SaveChanges();
            return Ok();
        }

        //query to fetch the department, course, section, subject and instructor (inner join)
        public IActionResult getAllDetailAssignInstructor()
        {
            try
            {
                var res = 
                    (
                    from asi in _context.Assignsubjects
                    join dep in _context.Departments on asi.DepartmentId equals dep.DepartmentId
                    join cor in _context.Courses on asi.CourseId equals cor.CourseId
                    join sub in _context.Subjects on asi.SubjectId equals sub.SubjectId
                    
                    select new DetailedAssignInstructor
                    {
                        AId = asi.AId,
                        Semester = asi.Semester,
                        DepartmentId = dep.DepartmentId,
                        CourseId = cor.CourseId,
                        DepartmentName = dep.DepartmentName,
                        CourseName = cor.CourseName,
                        YearLevel = asi.YearLevel,
                        SubjectId = sub.SubjectId,
                        SubjectCode = sub.SubjectCode,
                        SubjectName = sub.SubjectName,
                    }

                ).ToList();

                return Ok(res);
            }
            catch
            {
                return Ok("Entity not found.");
            }            
        }

        //query to delete the specific assign instructor
        public IActionResult deleteAssignInstructor(int aId)
        {
            _context.Assignsubjects.Remove(_context.Assignsubjects.Find(aId));
            _context.SaveChanges();
            return Ok();
        }

        //check if there is any existing data for assign instructor
        public IActionResult checkAssignInstructorExistingData(Assignsubject asi)
        {
            bool isThereExistingData = false;

            //if the row has already the existing datas and subject then this will return true
            var resExistingData = _context.Assignsubjects.Where(
                element => element. CourseId == asi.CourseId
                && element.Semester == asi.Semester
                && element.SubjectId == asi.SubjectId).FirstOrDefault();

            //it means if there is an identical data
            if(resExistingData != null)
            {
                isThereExistingData = true;
            }

            return Ok(resExistingData);
        }

        //check if there is any existing data for room
        public IActionResult checkRoomExistingData(Room room)
        {
            //if the row has already the existing datas and subject then this will return true
            var resExistingData = _context.Rooms.Where(element => element.RoomName == room.RoomName).FirstOrDefault();

            return Ok(resExistingData);
        }

        //check if there is any existing section id and subject id for assign instructor
        public IActionResult checkAssignInstructorExistingSubject(Assignsubject asi)
        {
            bool isThereExistingSubject = false;

            var resExistingSubject = _context.Assignsubjects.Where(
                element => element.CourseId == asi.CourseId
                && element.SubjectId == asi.SubjectId
            ).FirstOrDefault();

            //it means there is an identical subject and section
            if(resExistingSubject != null)
            {
                isThereExistingSubject = true;
            }

            return Ok(resExistingSubject);
        }

        //check if there is any existing data that matches both subject code and subject name
        public IActionResult checkSubCodeName(Subject sub)
        {
            var res = _context.Subjects.Where(
                element => element.SubjectCode == sub.SubjectCode
                && element.SubjectName == sub.SubjectName
            ).FirstOrDefault();

            return Ok(res);
        }


        //Academic Year API SECTION

        //check if there is any existing data that matches academic year name
        public IActionResult checkAcadYear(Acadyear acad)
        {
            var res = _context.Acadyears.Where(
                element => element.AcadYearName == acad.AcadYearName
            ).FirstOrDefault();

            return Ok(res);
        }

        public IActionResult createAcademicYear(Acadyear acad)
        {
            _context.Acadyears.Add(acad);
            _context.SaveChanges();

            return Ok();
        }

        public ActionResult<List<Acadyear>> getAcademicYear(){
            return  _context.Acadyears.ToList();
        }

        public IActionResult updateAcademicYear(Acadyear acad)
        {
            _context.Acadyears.Update(acad);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult deleteAcademicYear(int acadYearId)
        {
            var res = _context.Acadyears.Where(element => element.AcadYearId == acadYearId).FirstOrDefault();
            _context.Acadyears.Remove(res);
            _context.SaveChanges();
            return Ok();
        }

        //Regis Section Academic Details API

        public ActionResult<List<Regissection>> getRegissections(){
            return  _context.Regissections.ToList();
        }

        //to fetch the subjects handled of the instructor
        public IActionResult getRegisSection(int sectionID)
        {
            var res = 
            (
                from sec in _context.Sections
                join rs in _context.Regissections on sec.SectionId equals rs.SectionId
                join acad in _context.Acadyears on rs.AcadYearId equals acad.AcadYearId
                where sec.SectionId == sectionID

                select new RegisSectionAcad
                {
                    RegisSectionId = rs.RegisSectionId,
                    SectionId = sec.SectionId,
                    AcadYearId = acad.AcadYearId,
                    AcadYearName = acad.AcadYearName,
                    Semester = rs.Semester,
                    TotalStudents = rs.TotalStudents
                }

            ).ToList();

            return Ok(res);
        }

        //to fetch the unit load of the instructor
        public IActionResult getUnitLoad(int instructorId)
        {
            var res = 
            (
                from iau in _context.Instructorunitloads
                join ins in _context.Instructors on iau.InstructorId equals ins.InstructorId
                join acad in _context.Acadyears on iau.AcadYearId equals acad.AcadYearId
                where ins.InstructorId == instructorId

                select new InstructAcadUnit
                {
                    InstructorId = ins.InstructorId,
                    InstructorFname = ins.InstructorFname,
                    InstructorMname = ins.InstructorMname,
                    InstructorLname = ins.InstructorLname,
                    DepartmentId = ins.DepartmentId,
                    AcadYearId = acad.AcadYearId,
                    AcadYearName = acad.AcadYearName,
                    UnitLoad = iau.UnitLoad,
                    UnitLoadId = iau.UnitLoadId,
                    Semester = iau.Semester
                }

            ).ToList();

            return Ok(res);
        }

        public IActionResult createInstructorLoad(Instructorunitload iul)
        {
            
            var res = _context.Instructorunitloads.Where(x => x.AcadYearId == iul.AcadYearId && x.Semester == iul.Semester && x.InstructorId == iul.InstructorId).FirstOrDefault();
            if(res == null)
            {
                _context.Instructorunitloads.Add(iul);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return Ok(res);
            }


            
        }

        //query to delete the selected instructor
        public IActionResult deleteInstructorLoad(int IAUId)
        {
            var res = _context.Instructorunitloads.Where(element => element.UnitLoadId == IAUId).FirstOrDefault();
            _context.Instructorunitloads.Remove(res);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult checkInstructorLoad(Instructorunitload iul)
        {
            var res = _context.Instructorunitloads.Where(il => il.InstructorId == iul.InstructorId && il.AcadYearId == iul.AcadYearId && il.Semester == iul.Semester).FirstOrDefault();

            return Ok(res);
        }

        public IActionResult createRegisSection(Regissection rs)
        {
            var res = _context.Regissections.Where(x => x.AcadYearId == rs.AcadYearId && x.Semester == x.Semester && rs.SectionId == x.SectionId).FirstOrDefault();
            if(res == null)
            {
                _context.Regissections.Add(rs);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return Ok(res);
            }
        }

        //check if the same academic year and semester is registered
        public IActionResult checkRegisSection(Regissection rs)
        {
            var res = _context.Regissections.Where(
                element => element.AcadYearId == rs.AcadYearId
                && element.Semester == rs.Semester
                && element.SectionId == rs.SectionId
            ).FirstOrDefault();

            return Ok(res);
        }

        //deleting the selected academic details
        public IActionResult deleteRegisSection(int regisSectionId)
        {
            var res = _context.Regissections.Where(element => element.RegisSectionId == regisSectionId).FirstOrDefault();
            _context.Regissections.Remove(res);
            _context.SaveChanges();
            return Ok();
        }

        
        //STUDENT API ZONE
        public ActionResult<List<Studentprofile>> getStudents(){
            return  _context.Studentprofiles.ToList();
        }

        //query to create a student
        public IActionResult createStudent(Studentprofile stud)
        {

            //Check the data first if it has already an existing data
            var checkRes = _context.Studentprofiles.Where(rs => rs.SchoolId == stud.SchoolId).FirstOrDefault();

            if(checkRes == null)
            {
                if(stud.StudentMname == null)
                {
                    stud.StudentMname = "";
                }
                _context.Studentprofiles.Add(stud);
                _context.SaveChanges();
                makeDynamicAccountStudent();

                return Ok();
            }
            else
            {
                return Ok(checkRes);
            }
        }

        public IActionResult CheckEmailStudent(Studentprofile stud)
        {
            //If there is email address found
            var res = _context.Studentprofiles.Where(e => e.EmailAddress == stud.EmailAddress).FirstOrDefault();
            if(res == null)
            {   
                return Ok();
            }
            else
            {
                if(res.StudentId == stud.StudentId)
                {
                    return Ok();
                }
                else
                {
                    return Ok(res); 
                }
            }
        }

        //query to update the student
        public IActionResult updateStudent(Studentprofile stud)
        {
            var checkRes = _context.Studentprofiles.Where(rs => rs.SchoolId == stud.SchoolId).AsNoTracking().FirstOrDefault();

            if(checkRes == null)
            {
                if(stud.StudentMname == null)
                {
                    stud.StudentMname = "";
                }
                _context.Studentprofiles.Update(stud);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                //But if the reason is because it's the same student id // same student then validate
                // var checkRes2 = _context.Studentprofiles.Where(rs2 => rs2.SchoolId == stud.SchoolId && rs2.StudentId == stud.StudentId).FirstOrDefault();

                //detach
                //_context.Studentprofiles.State = EntityState.Detached;
                var studIdHolder = stud.StudentId;
                if(checkRes.StudentId == studIdHolder)
                {
                    //Then if it's not null then proceed to update. If the value is null however, return as duplicated school id
                    if(stud.StudentMname == null)
                    {
                        stud.StudentMname = "";
                    }
                    _context.Studentprofiles.Update(stud);
                    _context.SaveChanges();

                    return Ok();
                }
                else
                {
                    return Ok(checkRes);
                }
            }
        }

        //query to delete the selected student
        public IActionResult deleteStudent(int studentId)
        {
            _context.Studentprofiles.Remove(_context.Studentprofiles.Find(studentId));

            var res = _context.Studentenrollments.Where(element => element.StudentId == studentId).ToList();
            var res2 = _context.Authorizations.Where(element => element.Id == studentId && element.UserType == "student").FirstOrDefault();

            //before removing, deduct the total number of students from the enrolled sections first
            foreach(var val in res)
            {
                //get the needed value to update the number of students
                var deductStudent = _context.Regissections.Where(e => e.SectionId == val.SectionId && e.AcadYearId == val.AcadYearId && e.Semester == val.Semester).FirstOrDefault();
                if(deductStudent != null)
                {
                    deductStudent.TotalStudents -= 1;
                    _context.Regissections.Update(deductStudent);
                }
            }

            _context.Authorizations.Remove(res2);
            _context.Studentenrollments.RemoveRange(res);
            //_context.Studentenrollments.Remove(_context.Studentenrollments.Find(studentId));
            _context.SaveChanges();

            //_context.Database.ExecuteSqlRaw(deletecommand);

            return Ok();
        }


        public IActionResult getStudentEnrollment(int studentID)
        {
            var res = 
            (
                from studEn in _context.Studentenrollments
                join sec in _context.Sections on studEn.SectionId equals sec.SectionId
                join dep in _context.Departments on sec.DepartmentId equals dep.DepartmentId
                join cor in _context.Courses on sec.CourseId equals cor.CourseId
                join acad in _context.Acadyears on studEn.AcadYearId equals acad.AcadYearId
                where studEn.StudentId == studentID

                select new TableStudentEnroll
                {
                    EnrollmentId = studEn.EnrollmentId,
                    StudentId = studEn.StudentId,
                    SectionId = sec.SectionId,
                    AcadYearId = acad.AcadYearId,
                    Semester = studEn.Semester,
                    DepartmentName = dep.DepartmentName,
                    CourseName = cor.CourseName,
                    SectionName = sec.SectionName,
                    YearLevel = sec.YearLevel,
                    AcadYearName = acad.AcadYearName
                }

            ).ToList();

            return Ok(res);
        }

        public IActionResult checkStudentEnrollment(Studentenrollment asi)
        {

            bool checkData = false;
            //if the row has already the existing datas then this will return true
            var resExistingData = _context.Studentenrollments.Where(
                element => element.AcadYearId == asi.AcadYearId
                && element.Semester == asi.Semester
                && element.StudentId == asi.StudentId
                ).FirstOrDefault();

            if(resExistingData != null)
            {
                checkData = true;
            }

            return Ok(resExistingData);
        }

        public IActionResult enrollStudent(Studentenrollment asi)
        {
            if(asi != null)
            {
                
                _context.Studentenrollments.Add(asi);

                //after adding it you must increment the total students of the enrolled section.
                var res = _context.Regissections.Where(e => e.SectionId == asi.SectionId && e.AcadYearId == asi.AcadYearId && e.Semester == asi.Semester).FirstOrDefault();
                res.TotalStudents += 1;

                _context.Regissections.Update(res);
                _context.SaveChanges();
            }

            return Ok();
        }

        public IActionResult deleteEnrollmentStudent(int enrollmentId)
        {

            //Before removing the student enrollment,
            //get the necessary value first to deduct the total number of students of enrolled section

            var res = _context.Studentenrollments.Where(e => e.EnrollmentId == enrollmentId).FirstOrDefault();
            
            //after that, update the total number of students
            var deductStudent = _context.Regissections.Where(e => e.SectionId == res.SectionId && e.AcadYearId == res.AcadYearId && e.Semester == res.Semester).FirstOrDefault();
            if(deductStudent != null)
            {
                deductStudent.TotalStudents -= 1;
                _context.Regissections.Update(deductStudent);
            }

            _context.Studentenrollments.Remove(_context.Studentenrollments.Find(enrollmentId));

            //var res = _context.Regissections.Where(e => e.SectionId == asi.SectionId && e.AcadYearId == asi.AcadYearId && e.Semester == asi.Semester).FirstOrDefault();
            //res.TotalStudents += 1;

            _context.SaveChanges();

            return Ok();
        }

        // public IActionResult updateTotalStudents()
        // {
        //     var res = _context.Regissections.ToList();
        //     foreach(var reg in res)
        //     {
        //         reg.TotalStudents = 0;
        //         _context.Regissections.Update(reg);
        //         _context.SaveChanges();
        //     }

        //     return Ok();
        // }
    }
}