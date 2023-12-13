using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using matikApp.Models;

namespace matikApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthorizationApiController : ControllerBase
    {
        private readonly matikdbContext _context;
        public AuthorizationApiController(matikdbContext context)
        {
            _context = context;
        }

        public IActionResult loginUser(string userName, string password)
        {
            var res = _context.Authorizations.Where(rs => rs.Username == userName && rs.Password == password).FirstOrDefault();

            return Ok(res);
        }
    }
}