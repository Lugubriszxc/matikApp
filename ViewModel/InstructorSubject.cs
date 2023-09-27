using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class InstructorSubject
    {
        public int ShId { get; set; }
        public int InstructorId { get; set; }
        public string InstructorFname { get; set; }
        public string InstructorMname { get; set; }
        public string InstructorLname { get; set; }
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int SubjectUnit { get; set; }

    }
}