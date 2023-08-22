using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public int BuildingId { get; set; }
    }
}
