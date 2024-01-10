using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class PotentialSchedule
    {
        public int InstructorId { get; set; }
        public string InstructorFname { get; set; }
        public string InstructorLname { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Day { get; set; }
        public int TimeId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
    }
}