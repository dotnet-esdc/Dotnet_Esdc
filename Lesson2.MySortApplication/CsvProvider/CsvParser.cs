using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.MySortApplication.CsvProvider
{
    public class CsvParser<T> where T : class, new()
    {
        public List<T> ReadCSV(string path)
        {
            var resultList = new List<T>();

            var str = File.ReadAllLines(path);

            var header = str.Take(1)
                .Select(x => x.Split(';'))
                .First()
                .ToList();

            var body = str.Skip(1)
                .Select(x => x.Split(';'))
                .ToList();

            foreach (var strItem in body)
            {
                var nItem = new T();

                var properties = nItem.GetType().GetProperties();

                foreach (var propItem in properties)
                {
                    var index = header.IndexOf(propItem.Name);
                    var val = strItem[index];

                    propItem.SetValue(nItem, val);
                }

                resultList.Add(nItem);
            }

            return resultList;
        }
    }
}
