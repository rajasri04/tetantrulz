using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tetantrulz.Dtos
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool issubcribed { get; set; }
        public demoDTO demo { get; set; }
        public int demoId { get; set; }


    }
}