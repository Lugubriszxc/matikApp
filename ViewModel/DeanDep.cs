using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class DeanDep
    {
        //A class for both course and department
        public int DeanId { get; set; }
        public string DeanFname { get; set; }
        public string DeanMname { get; set; }
        public string DeanLname { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}