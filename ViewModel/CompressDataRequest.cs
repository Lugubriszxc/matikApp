using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class CompressDataRequest
    {
        public string Semester { get; set; }
        public int AcadYearId { get; set; }
        public List<RoomCompress> ValRooms { get; set; }

    }
}