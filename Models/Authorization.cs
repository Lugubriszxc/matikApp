﻿using System;
using System.Collections.Generic;

namespace matikApp.Models
{
    public partial class Authorization
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}
