using Lesson9.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9.Core.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        public ICollection<Category> GetCollection()
        {
            throw new NotImplementedException();
        }
    }
}
