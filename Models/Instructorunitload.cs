using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Instructorunitload
    {
        public int UnitLoadId { get; set; }
        public int UnitLoad { get; set; }
        public int InstructorId { get; set; }
        public int AcadYearId { get; set; }
        public string Semester { get; set; }
    }
}
