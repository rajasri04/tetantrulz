using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace tetantrulz.Models
{
    public class MyDBContext: DbContext
    {
        public MyDBContext()
        {

        }
        public DbSet<demo> demos { get; set; }
        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<movie> Movies { get; set; }// My domain models
    }
}