using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class CustomerOrderContext : DbContext
    {
        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Order> Orders { get; set; }
    }
}