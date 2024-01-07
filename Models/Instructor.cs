using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorFname { get; set; }
        public string InstructorMname { get; set; }
        public string InstructorLname { get; set; }
        public int DepartmentId { get; set; }
        public string EmailAddress { get; set; }
        public string SecretCode { get; set; }
    }
}
