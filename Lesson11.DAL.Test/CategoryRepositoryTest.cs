using System;
using Lesson11.My3tierApplication.Core.Entities;
using Lesson11.My3tierApplication.Core.Repositories;
using Lesson11.My3tierApplication.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lesson11.DAL.Test
{
    [TestClass]
    public class CategoryRepositoryTest
    {

        IRepository<Category, int> _repo;

        public CategoryRepositoryTest()
        {
            _repo = new CategoryRepository();
        }

        [TestMethod]
        public void TestGetCollection()
        {
            var data = _repo.GetCollection();
        }
    }
}
