using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Timeslot
    {
        public int TimeId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
