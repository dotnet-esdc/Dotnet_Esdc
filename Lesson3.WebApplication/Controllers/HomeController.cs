using Lesson3.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson3.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index/
        public ActionResult Index(int count = 3, int lastElementIndex = 0)
        {
            var products = ProductRepository.GetProducts()
                .Skip(lastElementIndex)
                .Take(count)
                .ToList();

            // 1) 0, 3 ---> 3
            // 2) 3, 3 ---> 6
            var lastElementId = lastElementIndex + count;

            ViewBag.LastElementId = lastElementId;

            return View(products);
        }

        public ActionResult Detail(int id)
        {
            var element = ProductRepository.GetProducts()
                .First(x => x.Id == id);

            return View(element);
        }

        public ActionResult Create()
        {
            var prod = new Product()
            {
                Id = 0,
                Name = "Your product name",
                Price = 100
            };

            return View(prod);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductRepository.CreateProduct(product);
            return View();
        }

        public ActionResult Update(int id)
        {
            var element = ProductRepository.GetProducts()
                .First(x => x.Id == id);

            return View(element);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            ProductRepository.UpdateProduct(product);

            return Redirect("/home/index");
        }

        public ActionResult Delete(int id)
        {
            var element = ProductRepository.GetProducts()
                .First(x => x.Id == id);

            return View(element);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            ProductRepository.DeleteProduct(product);

            return Redirect("/home/index");
        }

    }
}