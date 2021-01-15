using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tetantrulz.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool issubcribed { get; set; }
        public demo demo { get; set; } 
        public int demoId { get; set; }

    }
}