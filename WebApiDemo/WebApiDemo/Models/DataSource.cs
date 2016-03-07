using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class DataSource
    {
        private static IEnumerable<Customer> _customers;

        public static IEnumerable<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    BuildDataSource();
                }

                return _customers;
            }
        }

        private static IEnumerable<Order> _orders;

        public static IEnumerable<Order> Orders
        {
            get
            {
                if (_orders == null)
                {
                    BuildDataSource();
                }

                return _orders;
            }
        }

        private static void BuildDataSource()
        {
            CustomerOrderContext db = new CustomerOrderContext();
            if (db.Customers.Any())
            {
                _customers = db.Customers;
                _orders = db.Orders;
                return;
            }

            var customers = Enumerable.Range(1, 5).Select(e => new Customer
            {
                Id = e,
                Name = new[] { "Tony", "Mike", "John", "Peter", "Jimmy" }[e - 1],
                FavoriteColor = e < 2 ? Color.Red : e < 4 ? Color.Blue : Color.Yellow,
                Address = new Address
                {
                    City = new[] { "Redmond", "Shanghai", "Beijing", "Tokyo", "New York" }[e - 1],
                    Street = new[] { "One Microsoft Rd", "Zixing Rd", "Renming Rd", "Tokyo Rd", "the 51st" }[e - 1]
                },
                Orders = null
            });

            int orderId = 1;
            decimal price = 10.1m;
            foreach (var customer in customers)
            {
                customer.Orders = Enumerable.Range(1, 3).Select(e => new Order
                {
                    Id = orderId++,
                    Price = e + price++
                }).ToList();

                foreach (var order in customer.Orders)
                {
                    db.Orders.Add(order);
                }

                db.Customers.Add(customer);
            }

            db.SaveChanges();

            _customers = db.Customers;
            _orders = db.Orders;
        }
    }
}