using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Lesson13.CustomHRApplication.Models;

namespace Lesson13.CustomHRApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Staff>("Staffs");
            builder.EntitySet<ApplicationUser>("ApplicationUsers");
            builder.EntitySet<OrgUnit>("OrgUnits");
            builder.EntitySet<Position>("Positions");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
