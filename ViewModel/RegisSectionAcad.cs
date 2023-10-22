using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class RegisSectionAcad
    {
        public int RegisSectionId { get; set; }
        public int SectionId { get; set; }
        public int AcadYearId { get; set; }
        public string AcadYearName { get; set; }
        public string Semester { get; set; }
        public int TotalStudents { get; set; }
    }
}