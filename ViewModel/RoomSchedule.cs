using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class RoomSchedule
    {
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public int InstructorId { get; set; }
        public int RoomId { get; set; }
        public int TimeId { get; set; }
        public int Day {get; set;}
        // Constructor
        public RoomSchedule(int sectionId, int subjectId, int instructorId, int roomId, int timeId, int day)
        {
            SectionId = sectionId;
            SubjectId = subjectId;
            InstructorId = instructorId;
            RoomId = roomId;
            TimeId = timeId;
            Day = day;
        }
    }
}