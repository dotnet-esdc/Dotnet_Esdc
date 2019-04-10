using Lesson11.My3tierApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.My3tierApplication.Core.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        ICollection<TEntity> GetCollection();

        void Create(TEntity item);

        void Update(TKey key, TEntity item);

        void Delete(TKey key);
    }
}
