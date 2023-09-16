using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class DetailedAssignInstructor
    {
        public int AId { get; set; }
        public string Semester { get; set; }
        public int StudentCount { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string YearLevel { get; set; }
        public int InstructorId { get; set; }
        public string InstructorFname { get; set; }
        public string InstructorMname { get; set; }
        public string InstructorLname { get; set; }
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
    }
}