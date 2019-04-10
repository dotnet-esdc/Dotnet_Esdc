using Lesson11.My3tierApplication.Core.Entities;
using Lesson11.My3tierApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.BLL.Test.Repositories
{
    public class TestCategoryRepository : IRepository<Category, int>
    {
        public void Create(Category item)
        {
        }

        public void Delete(int key)
        {
        }

        public ICollection<Category> GetCollection()
        {
            return Enumerable.Range(1, 10).Select(x => new Category()
            {
                Id = x,
                Name = "Category " + x
            }).ToList();
        }

        public void Update(int key, Category item)
        {
        }
    }
}
