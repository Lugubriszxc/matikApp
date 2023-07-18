using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }
    }
}
