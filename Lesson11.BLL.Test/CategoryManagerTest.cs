using System;
using Lesson11.BLL.Test.Repositories;
using Lesson11.My3tierApplication.BLL;
using Lesson11.My3tierApplication.Core.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Lesson11.BLL.Test
{
    [TestClass]
    public class CategoryManagerTest
    {
        private IManager _mng;

        public CategoryManagerTest()
        {
            var testRepo = new TestCategoryRepository();
            var validator = new CategoryValidator();
            _mng = new CategoryManager(testRepo, validator);
        }

        [TestMethod]
        public void TestGetCategories()
        {
            var hasData = _mng.GetCategories().Any();

            Assert.IsTrue(hasData);
        }

        [TestMethod]
        public void TestTryCreate()
        {
            var result = _mng.TryCreate(new My3tierApplication.Core.Entities.Category());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestTryUpdate()
        {
            var result = _mng.TryUpdate(1, new My3tierApplication.Core.Entities.Category());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestTryDelete()
        {
            var result = _mng.TryDelete(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidate()
        {
            var result = _mng.Validate(new My3tierApplication.Core.Entities.Category());

            Assert.IsTrue(result);
        }

    }
}
