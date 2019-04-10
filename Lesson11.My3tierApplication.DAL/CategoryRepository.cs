using Lesson11.My3tierApplication.Core.Entities;
using Lesson11.My3tierApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.My3tierApplication.DAL
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private MyApplicationDbContext _context = new MyApplicationDbContext();

        public CategoryRepository()
        {
#if DEBUG
            _context.Database.Log = log => Debug.WriteLine(log);
#endif
        }

        public void Create(Category item)
        {
            _context.Database.ExecuteSqlCommand("EXEC CategoriesCreate @name = '@nameVal'", 
                new SqlParameter("@nameVal", item.Name));
        }

        public void Delete(int key)
        {
            _context.Database.ExecuteSqlCommand("EXEC CategoriesDelete @id = @idVal", 
                new SqlParameter("@idVal", key));
        }

        public ICollection<Category> GetCollection()
        {
            return _context.Database.SqlQuery<Category>("EXEC CategoriesRead")
                .ToList();
        }

        public void Update(int key, Category item)
        {
            _context.Database.ExecuteSqlCommand("EXEC CategoriesUpdate @id = @idVal, @name = '@nameVal'",
                new SqlParameter("@idVal", key),
                new SqlParameter("@nameVal", item.Name));
        }
    }
}
