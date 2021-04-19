using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using Newtonsoft.Json;



namespace MMTConsoleApp
{
    class ConsumeProduct
    {

        public void GetAllProductData() //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:17643/Product/GetProducts"); //URI  
                Console.WriteLine(Environment.NewLine + result);
            }
        }

        public void GetAllProducts()
        {
            string apiUrl = "http://localhost:17643/Product";            
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(apiUrl + "/GetProducts");

            List<Product> deserializedProduct = JsonConvert.DeserializeObject<List<Product>>(json);
                        
            if (deserializedProduct.Count > 0)
            {
                foreach (Product product in deserializedProduct)
                {
                    Console.WriteLine(product.Name);
                }
            }
            else
            {
                Console.WriteLine("No records found.");
            }

        }
          
    }

    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
