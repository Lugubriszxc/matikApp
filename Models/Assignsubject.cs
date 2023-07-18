using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Assignsubject
    {
        public int AId { get; set; }
        public int ASubjectId { get; set; }
        public int AClassId { get; set; }
        public string ASemester { get; set; }
        public int AInstructorId { get; set; }
    }
}
