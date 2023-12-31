using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Studentenrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public int AcadYearId { get; set; }
        public string Semester { get; set; }
    }
}
