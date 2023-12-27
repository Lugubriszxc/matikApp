using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Roomschedule
    {
        public int RoomSchedId { get; set; }
        public int InstructorId { get; set; }
        public int RoomId { get; set; }
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public int Day { get; set; }
        public int TimeId { get; set; }
        public int AcadYearId { get; set; }
        public string Semester { get; set; }
    }
}
