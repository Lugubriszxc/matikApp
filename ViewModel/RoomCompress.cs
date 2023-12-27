using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class RoomCompress
    {
        public int InstructorId { get; set; }
        public int RoomId { get; set; }
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public int Day { get; set; }
        public int TimeId { get; set; }
        public int AcadYearId { get; set; }
        public string Semester { get; set; }
        public RoomCompress(int instructorId, int roomId, int sectionId, int subjectId, int day, int timeId, int acadYearId, string semester)
        {
            SectionId = sectionId;
            SubjectId = subjectId;
            InstructorId = instructorId;
            RoomId = roomId;
            TimeId = timeId;
            Day = day;
            AcadYearId = acadYearId;
            Semester = semester;
        }
    }
}