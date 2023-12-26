using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using matikApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace matikApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PageInstructorApiController : ControllerBase
    {
        private readonly matikdbContext _context;

        public PageInstructorApiController(matikdbContext context)
        {
            _context = context;
        }

        public IActionResult loadUserDetail(int instructorId)
        {
            var res = _context.Instructors.Where(rs => rs.InstructorId == instructorId).FirstOrDefault();
            return Ok(res);
        }
    }
}