using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using OroUostoSistema.DatabaseOroUostas;
using OroUostoSistema.Models;

namespace OroUostoSistema.Controllers
{
    public class TestDataController : ApiController
    {
        DB db = new DB();
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
        }
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public IEnumerable<Product> GetAllTestData()
        {
            return products;
        }

        public HttpResponseMessage GetTestData(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NoContent); ;
            }
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            JObject responseJson = JObject.FromObject(product);
            response.Content = new StringContent(responseJson.ToString(), Encoding.UTF8, "application/json");
            return response;
        }
        public HttpResponseMessage GetCreateMockData(int id)
        {
            var tmp = new MyMockData(db);
            tmp.CreateMockData();
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
