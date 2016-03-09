using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Core.UriParser;
using Microsoft.OData.Edm;
using WebApiDemo.Models;

namespace WebApiDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.SetUrlConventions(ODataUrlConventions.ODataSimplified);

            config.MapODataServiceRoute("odata", "odata", GetEdmModel());
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Order>("Order");
            return builder.GetEdmModel();
        }
    }
}
