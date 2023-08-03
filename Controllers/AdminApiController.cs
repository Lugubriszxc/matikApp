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
                    DeanMname = "",
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
    }
}