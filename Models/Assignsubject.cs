﻿using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Assignsubject
    {
        public int AId { get; set; }
        public int SubjectId { get; set; }
        public string Semester { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string YearLevel { get; set; }
    }
}
