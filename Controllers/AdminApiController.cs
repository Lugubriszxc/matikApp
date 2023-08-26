using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using matikApp.Models;
using matikApp.ViewModel;

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
            _context.Departments.Add(dep);
            _context.SaveChanges();

            return Ok();
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
            _context.Courses.Add(cor);
            _context.SaveChanges();

            return Ok();
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
                join i in _context.Instructors
                on d.DepartmentId equals i.DepartmentId
                
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
                join i in _context.Instructors
                on d.DepartmentId equals i.DepartmentId

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

        //query to fetch the instructor list
        public ActionResult<List<Instructor>> getInstructors(){
            return  _context.Instructors.ToList();
        }

        //query to create a dean
        public IActionResult createInstructor(Instructor i)
        {
            if(i.InstructorMname == null)
            {
                i.InstructorMname = "";
            }
            _context.Instructors.Add(i);
            _context.SaveChanges();

            return Ok();
        }

        //query to delete the selected instructor
        public IActionResult deleteInstructor(int instructorId)
        {
            _context.Instructors.Remove(_context.Instructors.Find(instructorId));
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
    }
}