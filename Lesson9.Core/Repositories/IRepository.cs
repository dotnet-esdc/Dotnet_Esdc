using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9.Core.Repositories
{
    public interface IRepository<T>
    {
        ICollection<T> GetCollection();
    }
}
