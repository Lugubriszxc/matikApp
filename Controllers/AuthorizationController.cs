using Microsoft.AspNetCore.Mvc;
using matikApp.Models;

namespace matikApp.Controllers
{
    public class AuthorizationController : Controller
    {
       
        public ActionResult Signup(){
            return View();
        }

        public ActionResult Signin(){
            return View();
        }

        public ActionResult SigninInstructor()
        {
            return View("PartialInstructor/SigninInstructor");
        }

        public ActionResult SigninStudent()
        {
            return View("PartialStudent/SigninStudent");
        }
    }
}