using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Lesson10.AdvancedWeb.Attributes
{
    public class MyCustomAttribute: FilterAttribute
    {
        public MyCustomAttribute()
        {

        }

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }
        

    }
}