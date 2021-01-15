using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tetantrulz.Models;

namespace tetantrulz.NewCustmerViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<demo> demo { get; set; }
        public Customer Customer { get; set; }
    }
}