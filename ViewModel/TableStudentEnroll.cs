using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class TableStudentEnroll
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public int AcadYearId { get; set; }
        public string Semester { get; set; }
        public string DepartmentName { get; set; }
        public string CourseName { get; set; }
        public string SectionName { get; set; }
        public string YearLevel { get; set; }
        public string AcadYearName { get; set; }
    }
}