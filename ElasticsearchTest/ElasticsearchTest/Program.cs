using ElasticsearchTest.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticsearchTest
{
    internal class Program
    {
        private static IElasticClient _client = ElasticConfig.GetClient();
        public static void Insert(Car car, string indexName)
        {
            _client.Index(car, i => i
                  .Id(car.CarID)
                  .Index(indexName)
                  );
        }

        public static Car GetCarByID(string Id, string indexName)
        {
            var result = _client.Search<Car>(q => q
                              .Index(indexName)
                              .Query(qq => qq.Match(m => m.Field(f => f.CarID).Query(Id))
                              ).Size(1));

            return result.Documents.FirstOrDefault();
        }
        static void Main(string[] args)
        {
            Car carToyota = new Car()
            {
                CarID = 1,
                Color = "Black",
                CreatedDate = DateTime.Now,
                Maker = "TOYOTA",
                Price = 2170000
            };
            Car carSubaru = new Car()
            {
                CarID = 2,
                Color = "Blue",
                CreatedDate = DateTime.Now,
                Maker = "SUBARU",
                Price = 2970000
            };
            Insert(carToyota, "vehicle");
            Insert(carSubaru, "vehicle");
            Console.WriteLine(GetCarByID("1", "vehicle").Maker);
            Console.WriteLine(GetCarByID("2", "vehicle").Maker);
        }
    }
}
