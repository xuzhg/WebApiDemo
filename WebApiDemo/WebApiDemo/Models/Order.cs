using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class Order
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public Customer Customer { get; set; }
    }
}