using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10.WorkingWithSP
{
    class Program
    {
        static void Main(string[] args)
        {
            // example 1
            // via Entity framework from database
            
            using (var context = new ViaEF.MyExampleEntities())
            {
                var result1 = context.GetProducts();

                var result2 = context.GetProductsFilteredByRating(4);

                var result3 = context.GetProductsById(1);

                var result4 = context.GetTwoCollectionOfProducts();
            }


            // example 2
            // 

            using (var context = new ViaEF.MyExampleEntities())
            {
                context.Database.Log = logInfo => Debug.WriteLine(logInfo);

                var result =  context.Database.SqlQuery<ViaEF.Products>("SELECT * FROM Products").ToList();

                var result2 = context.Database.SqlQuery<ViaEF.Products>("exec GetProducts").ToList();

                var result3 = context.Products.Select(x => new { x.ID, x.Name }).Where(x => x.ID > 2).ToList();

            }
            

        }
    }
}
