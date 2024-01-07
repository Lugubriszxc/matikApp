using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Studentprofile
    {
        public int StudentId { get; set; }
        public string StudentFname { get; set; }
        public string StudentMname { get; set; }
        public string StudentLname { get; set; }
        public string SchoolId { get; set; }
        public string EmailAddress { get; set; }
        public string SecretCode { get; set; }
    }
}
