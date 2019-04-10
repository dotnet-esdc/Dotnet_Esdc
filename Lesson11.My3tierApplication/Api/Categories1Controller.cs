using Lesson11.My3tierApplication.BLL;
using Lesson11.My3tierApplication.Core.Entities;
using Lesson11.My3tierApplication.Core.Managers;
using Lesson11.My3tierApplication.Core.Repositories;
using Lesson11.My3tierApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lesson11.My3tierApplication.Api
{
    public class Categories1Controller : ApiController
    {
        private IManager _mng;

        public Categories1Controller()
        {
            IRepository<Category, int> repo = new CategoryRepository();
            IValidator validator = new CategoryValidator();
            _mng = new CategoryManager(repo, validator);
        }

        public List<Category> Get()
        {
            return _mng.GetCategories().ToList();
        }
    }
}
