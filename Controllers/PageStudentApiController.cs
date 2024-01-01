using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using matikApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace matikApp.Controllers
{
        [Route("api/[controller]/[action]")]
    public class PageStudentApiController : ControllerBase
    {
        private readonly matikdbContext _context;

        public PageStudentApiController(matikdbContext context)
        {
            _context = context;
        }

        public IActionResult loadUserDetail(int studentId)
        {
            var res = _context.Studentprofiles.Where(rs => rs.StudentId == studentId).FirstOrDefault();
            return Ok(res);
        }
    }
}