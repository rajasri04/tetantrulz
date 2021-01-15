using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tetantrulz.Models;

namespace tetantrulz.viewmodel
{
    public class RandomMovieViewModel
    {
        public movie movie { get; set; }
        public List<Customer> customers { get; set; }
        public List<Customer> Customer { get; internal set; }
    }
}