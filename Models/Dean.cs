using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Dean
    {
        public int DeanId { get; set; }
        public string DeanFname { get; set; }
        public string DeanMname { get; set; }
        public string DeanLname { get; set; }
        public int DepartmentId { get; set; }
    }
}
