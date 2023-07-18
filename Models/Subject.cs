using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int SubjectUnit { get; set; }
    }
}
