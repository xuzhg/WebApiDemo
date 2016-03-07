using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.OData;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class CustomersController : ODataController
    {
        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(DataSource.Customers);
        }

        [EnableQuery]
        public IHttpActionResult Get(int key)
        {
            return Ok(DataSource.Customers.FirstOrDefault(c => c.Id == key));
        }
    }
}