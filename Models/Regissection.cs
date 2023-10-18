using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Regissection
    {
        public int RegisSectionId { get; set; }
        public int SectionId { get; set; }
        public int AcadYearId { get; set; }
        public string Semester { get; set; }
        public int TotalStudents { get; set; }
    }
}
