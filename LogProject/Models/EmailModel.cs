﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogProject.Models
{
    public class EmailModel
    {
        public string From { get; set; }
        public string To { get; set; }

        public string Body { get; set; }
    }
}