using Lesson9.Core.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Lesson9.CoreTest.TestRepositories;

namespace Lesson9.CoreTest
{
    [TestClass]
    public class ProductReportManagerTest
    {
        [TestMethod]
        public void GetDataReturnAnyValue()
        {
            var prodRepo = new ProductTestRepository();
            var catRepo = new CategoryTestRepository();
            var clRepo = new ClientTestRepository();

            var manager = new ProductReportManager(prodRepo, clRepo, catRepo);

            var data = manager.GetData();


            Assert.IsTrue(data.Count > 0);
        }

        [TestMethod]
        public void GetDataReturnIsCorrect()
        {
            var prodRepo = new ProductTestRepository();
            var catRepo = new CategoryTestRepository();
            var clRepo = new ClientTestRepository();

            var manager = new ProductReportManager(prodRepo, clRepo, catRepo);

            var data = manager.GetData();

            var clients = clRepo.GetCollection();
            var categories = catRepo.GetCollection();

            var isCorrect = true;

            foreach (var item in data)
            {
                var currentCategoryName = item.CategoryName;
                var categoryName = categories.First(x => x.Id == item.CategoryId).Name;

                var currentClientName = item.ClientName;
                var clientName = clients.First(x => x.Id == item.ClientId).Name;

                isCorrect = string.Equals(currentCategoryName, categoryName)
                    && string.Equals(currentClientName, clientName);

                if (!isCorrect)
                    break;

            }

            Assert.IsTrue(isCorrect);

        }

    }
}
