using Lesson11.My3tierApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.My3tierApplication.Core.Managers
{
    public interface IManager
    {
        ICollection<Category> GetCategories();

        bool TryCreate(Category category);

        bool TryUpdate(int id, Category category);

        bool TryDelete(int id);

        bool Validate(Category category);
    }
}
