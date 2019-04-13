using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Lesson12_MyCoolStore_Application.Entities;

namespace Lesson12_MyCoolStore_Application {

    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<Sale>("Sales");
            builder.EntitySet<SaleDetail>("SaleDetails");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

        }
    }

}
