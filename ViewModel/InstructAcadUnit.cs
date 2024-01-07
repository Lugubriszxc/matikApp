using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class InstructAcadUnit
    {
        public int InstructorId { get; set; }
        public string InstructorFname { get; set; }
        public string InstructorMname { get; set; }
        public string InstructorLname { get; set; }
        public int DepartmentId { get; set; }
        public int AcadYearId { get; set; }
        public string AcadYearName { get; set; }
        public int UnitLoadId { get; set; }
        public int UnitLoad { get; set; }
        // public string Overload { get; set; }
        public string Semester { get; set; }
    }
}