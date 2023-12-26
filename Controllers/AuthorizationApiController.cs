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

        public IActionResult loginUser(string userName, string password, string userType)
        {
            //makeDynamicAccountInstructor();
            var res = _context.Authorizations
            .AsEnumerable() // Fetch data from the database
            .FirstOrDefault(rs => 
                rs.Username.Equals(userName, StringComparison.Ordinal) && 
                rs.Password.Equals(password, StringComparison.Ordinal) && 
                rs.UserType == userType
            );

            return Ok(res);
        }

        public IActionResult logoutUser()
        {
            //HttpContext.Session.Clear();
            return Ok();
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
    }
}