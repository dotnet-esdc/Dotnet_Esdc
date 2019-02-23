using Lesson2.MySortApplication.CsvProvider;
using Lesson2.MySortApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.MySortApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var strCitites = "cities.csv";


            var strProds = "products.csv";

            var parserCity = new CsvParser<City>();
            var cities = parserCity.ReadCSV(strCitites);


            var parserProd = new CsvParser<ProductModel>();
            var products = parserProd.ReadCSV(strProds);


        }

        private static void MethodWithObject(object arg)
        {

            var val = Convert.ToInt32(arg);

            /*
             * some code
             */
        }

        private void Part1()
        {
            // 1) create collection products 
            // 2) sort product
            //
            //

            Random r = new Random();

            List<Product> productList = Enumerable.Range(1, 100)
                .Select(x => new Product()
                {
                    Id = x,
                    Name = "Product_" + x,
                    Price = Convert.ToSingle(r.NextDouble())
                }).ToList();


            // let's sort

            MyFilter<Product> prodFilter = new MyFilter<Product>();

            Func<Product, bool> myComparator1 = (item) =>
            {
                return item.Price > 0.5;
            };
            Func<Product, bool> myComparator1_1 = (item) => { return item.Price > 0.5; };

            List<Product> result1 = prodFilter.Filter(productList, myComparator1);
            List<Product> result2 = prodFilter.Filter(productList, MyComparator);
            List<Product> result3 = prodFilter.Filter(productList, (item) => { return item.Price > 0.5; });
            List<Product> result4 = prodFilter.Filter(productList, item => item.Price > 0.5);

            // example 2

            List<Category> categoryList = Enumerable.Range(1, 100)
                    .Select(x => new Category()
                    {
                        Id = x,
                        Name = "Category_" + x,
                        Amount = r.Next(1, 100)
                    }).ToList();


            MyFilter<Category> categFilter = new MyFilter<Category>();
            List<Category> result5 = categFilter.Filter(categoryList, item => item.Amount > 70);

        }

        private void Part2()
        {
            Random r = new Random();

            List<Product> productList = Enumerable.Range(1, 100)
                .Select(x => new Product()
                {
                    Id = x,
                    Name = "Product_" + x,
                    Price = Convert.ToSingle(r.NextDouble())
                }).ToList();

            // filter by price > 0.5
            // get avg price
            // get items count
            // get sum price
            // if avg < 0.6 && count > 40


            // example 1
            float avg = 0;
            float sum = 0;
            int count = 0;

            for (int i = 0; i < productList.Count; i++)
            {
                Product item = productList[i];
                if (item.Price > 0.5)
                {
                    sum += item.Price;
                    count++;
                }
            }

            avg = sum / count;

            bool result = avg < 0.6 && count > 40;


            // example 2

            var result2 = productList
                .Where(x => x.Price > 0.5)
                .Select(x => new { x, i = 1 })
                .GroupBy(x => x.i)
                .Select(x => new { Avg = x.Average(f => f.x.Price), Sum = x.Sum(f => f.x.Price), Count = x.Count() })
                .First();

            var preResult = productList
                .Where(x => x.Price > 0.5);

            var avg_1 = preResult.Average(x => x.Price);
            var sum_1 = preResult.Sum(x => x.Price);
            var count_1 = preResult.Count();

            bool result3 = result2.Avg < 0.6 && result2.Count > 40;

            /*

             1) filter -> List<Product>
             2) select -> List<Product, int>
             3) group by ->
             name     | id
             object 1 | 1
             object 2 | 1
             object 3 | 2
             object 4 | 2

             --->

             [{   key: 1,
                 values: ["object 1", "object 2"] },
             {   key: 2,
                 values: ["object 2", "object 4"]}]


              */
        }

        private void Part3()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FullName = "Sam", Age = 20, Gender = Gender.Male, Rating = 5 });
            people.Add(new Person() { FullName = "Tomas", Age = 60, Gender = Gender.Male, Rating = 3 });
            people.Add(new Person() { FullName = "Adison", Age = 10, Gender = Gender.Male, Rating = 2 });
            people.Add(new Person() { FullName = "Alice", Age = 25, Gender = Gender.Female, Rating = 5 });
            people.Add(new Person() { FullName = "Martha", Age = 40, Gender = Gender.Female, Rating = 3 });

            // get avg rating from people whe older than 20
            var result1 = people
                .Where(x => x.Age > 20)
                .Average(x => x.Rating);

            // get females count
            var result2 = people
                .Where(x => x.Gender == Gender.Female)
                .Count();

            // среднее значение рейтинга для группы людей в возрастном диапазоне [1-30] [30-60] etc
            // в разрезе полов

            var result4 = people
                .Select(x => new { x.FullName, x.Age, x.Gender, x.Rating, AgeCategory = x.Age / 30 })
                .GroupBy(x => new { x.Gender, x.AgeCategory })
                .Select(x => new
                {
                    x.Key.AgeCategory,
                    x.Key.Gender,
                    AvgRatig = x.Average(f => f.Rating)
                })
                .ToList();

            var genders = people
                .Select(x => x.Gender)
                .Distinct();

            var minRating = people
                .Min(x => x.Rating);

            var maxRating = people
                .Max(x => x.Rating);

            var minMaleRating = people
                .Where(x => x.Gender == Gender.Male)
                .Min(x => x.Rating);


        }

        private static void ExampleEnumerableRange(int start, int count)
        {
            List<int> result = new List<int>();

            for (int i = start; i < count; i++)
            {
                result.Add(i);
            }


            //return result;
        }

        static bool MyComparator(Product item)
        {
            return item.Price < 0.5;
        }

        public static List<Product> Test1()
        {
            List<Product> input = new List<Product>();
            List<Product> result = new List<Product>();
            for (int i = 0; i < input.Count; i++)
            {
                Product item = input[i];
                if (item.Price > 0.5)
                    result.Add(item);
            }
            return result;
        }

        public static List<Product> Test2()
        {
            List<Product> input = new List<Product>();
            List<Product> result = new List<Product>();
            for (int i = 0; i < input.Count; i++)
            {
                Product item = input[i];
                if (item.Price < 0.5)
                    result.Add(item);
            }
            return result;
        }

        public static List<Product> Test3()
        {
            List<Product> input = new List<Product>();
            List<Product> result = new List<Product>();
            for (int i = 0; i < input.Count; i++)
            {
                Product item = input[i];
                if (item.Name.Contains("snikers"))
                    result.Add(item);

            }
            return result;
        }

        public static List<Category> Test4()
        {
            List<Category> input = new List<Category>();
            List<Category> result = new List<Category>();
            for (int i = 0; i < input.Count; i++)
            {
                Category item = input[i];
                if (item.Amount > 10)
                    result.Add(item);
            }
            return result;
        }

    }
}
