using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matikApp.ViewModel
{
    public class RoomBuild
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
    }
}