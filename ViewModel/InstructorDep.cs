using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class InstructorDep
    {
        //A class for both instructor and department
        public int InstructorId { get; set; }
        public string InstructorFname { get; set; }
        public string InstructorMname { get; set; }
        public string InstructorLname { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}