using System;
using System.Collections.Generic;

using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data.Model.Request
{
    public class GetnPost
    {        
        static async Task Main()
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri("http://dev.shopiconnect.com/");
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "api/product/123";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            Product product = JsonConvert.DeserializeObject<Product>(resp);
            //Console.WriteLine(response);
            Console.WriteLine(resp);
            //Console.WriteLine(product);


            //var impr = new ImportProductsRequest();
            //var impr = new Product();

            string json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //var url2 = "https://httpbin.org/post";
            var url2 = "http://dev.shopiconnect.com/api/productImport/ImportDeltaProducts";
            using var client2 = new HttpClient();

            HttpResponseMessage response2 = await client2.PostAsync(url2, data);

            string result = response2.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
    }

    public class ImportProductsRequest
    {
        public List<Product> ProductList;

    }
    
    public class Product    
    {
        public string id { get; set; }
        public int cloudId { get; set; }
        public string productName { get; set; }
        public double listPrice { get; set; }
        public string headline { get; set; }
        public double strikeOutPrice { get; set; }
        public bool IsCampaign { get; set; }
        public bool inStock { get; set; }
        public bool isShipmentFree { get; set; }
        public List<Variant> variants { get; set; }
        public List<Filter> filters { get; set; }
        public Picture picture { get; set; }
        public List<Picture2> pictures { get; set; }
        public string productDetailUrl { get; set; }
        public List<object> reviews { get; set; }
        public double point { get; set; }
        public int quantity { get; set; }
        public Category category { get; set; }
        public string sku { get; set; }
        public bool UserFriendly { get; set; }
    }

    public class Feature    
    {
        public int cloudId { get; set; }
        public string displayName { get; set; }
        public string value { get; set; }
        public string productId { get; set; }
        public bool isProductChanger { get; set; }
        public double strikeoutPrice { get; set; }
        public double price { get; set; }
        public bool isInStock { get; set; }
        public int order { get; set; }
    }

    public class Selected   
    {
        public int cloudId { get; set; }
        public string displayName { get; set; }
        public string value { get; set; }
        public string productId { get; set; }
        public bool isProductChanger { get; set; }
        public double strikeoutPrice { get; set; }
        public double price { get; set; }
        public bool isInStock { get; set; }
        public int order { get; set; }
    }

    public class Variant
    {
        public int cloudId { get; set; }
        public string groupName { get; set; }
        public string groupId { get; set; }
        public List<Feature> features { get; set; }
        public int order { get; set; }
        public Selected selected { get; set; }
    }

    public class Filter
    {
        public string filterItemId { get; set; }
    }

    public class Picture
    {
        public string url { get; set; }
        public int order { get; set; }
        public bool isVideo { get; set; }
    }

    public class Picture2
    {
        public string url { get; set; }
        public int order { get; set; }
        public bool isVideo { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool isRoot { get; set; }
        public bool isLeaf { get; set; }
        public string parentCategoryId { get; set; }
        public string description { get; set; }
        public int order { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public bool UserFriendly { get; set; }
    }

}

