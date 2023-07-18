using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using matikApp.Models;

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

        public IActionResult createDepartment(string dep)
        {
            Department d = new Department();
            d.DepartmentName = dep;
            _context.Departments.Add(d);
            _context.SaveChanges();

            return Ok();
        }

        public ActionResult<List<Department>> getDepartment(){
            return  _context.Departments.ToList();
        }
    }
}