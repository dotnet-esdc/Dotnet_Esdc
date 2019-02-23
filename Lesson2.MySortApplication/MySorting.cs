using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.MySortApplication
{
    public class MyFilter<T>
    {
        public List<T> Filter(List<T> collection, Func<T, bool> comparator)
        {
            List<T> result = new List<T>();

            foreach (T item in collection)
            {
                if (comparator(item))
                    result.Add(item);
            }

            return result;
        }
    }
}
