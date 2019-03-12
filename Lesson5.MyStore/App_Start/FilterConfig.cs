using System.Web;
using System.Web.Mvc;

namespace Lesson5_MyStore {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
