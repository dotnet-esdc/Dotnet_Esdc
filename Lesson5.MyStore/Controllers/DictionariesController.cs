using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5_MyStore.Controllers
{
    public class DictionariesController : Controller
    {
        // GET: Dictionaries
        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Employees()
        {
            return View();
        }

    }
}