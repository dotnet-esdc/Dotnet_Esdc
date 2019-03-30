using Lesson9.Core.DTOs;
using Lesson9.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson9.WebStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Report()
        {
            //var manager = new ProductReportManager();

            //var data = manager.GetData();

            var data = new List<ProductReportDTO>();

            data.Add(new ProductReportDTO()
            {
                CategoryName = "Cat1",
                ClientName = "Cl1",
                ProductName = "Prod1"
            });

            data.Add(new ProductReportDTO()
            {
                CategoryName = "Cat1",
                ClientName = "Cl1",
                ProductName = "Prod2"
            });
            data.Add(new ProductReportDTO()
            {
                CategoryName = "Cat1",
                ClientName = "Cl1",
                ProductName = "Prod3"
            });
            data.Add(new ProductReportDTO()
            {
                CategoryName = "Cat1",
                ClientName = "Cl2",
                ProductName = "Prod4"
            });
            data.Add(new ProductReportDTO()
            {
                CategoryName = "Cat1",
                ClientName = "Cl2",
                ProductName = "Prod5"
            });
            data.Add(new ProductReportDTO()
            {
                CategoryName = "Cat1",
                ClientName = "Cl2",
                ProductName = "Prod6"
            });

            return View(data);
        }

    }
}