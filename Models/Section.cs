using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Section
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string YearLevel { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
    }
}
