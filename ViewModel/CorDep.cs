using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class CorDep
    {
        //A class for both course and department
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}