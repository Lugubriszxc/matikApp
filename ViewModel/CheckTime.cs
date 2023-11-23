using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class CheckTime
    {
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public int InstructorId { get; set; }
        public int RoomId { get; set; }
        public int TimeId { get; set; }
        public int Day {get; set;}
        public string StartTime {get; set;}
        public string EndTime {get; set;}
    }
}