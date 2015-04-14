using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Example.Web.Models
{
    public class Server
    {
        //pet store settingid is 21
        HttpClient client = null;
        public Server()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://service.flexibleinventory.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private string encrypt(string origion)
        {
            //return origion;
            return Security.EncryptPassword(origion);
        }
        public async Task<List<ProductM>> GetProducts(string productName = "%")
        {
            string link = "api/WebProducts/" + encrypt(String.Format("?settingId=21&productName={0}&serverPassword=123", productName));
            var response = await client.GetAsync(link);
            if (response.IsSuccessStatusCode)
            {
                var ret = response.Content.ReadAsStringAsync();
                var temp = JsonConvert.DeserializeObject<List<ProductM>>(ret.Result);

                return temp;
            }
            return null;
        }
        public async Task<ProductDetailM> GetProductDetail(int productId)
        {
            string link = "api/WebProductDetail/" + encrypt(String.Format("?productId={0}&serverPassword=123", productId));
            var response = await client.GetAsync(link);
            if (response.IsSuccessStatusCode)
            {
                var ret = response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductDetailM>(ret.Result);
            }
            return null;
        }
        public async Task<List<CategoryM>> GetCategories(int settingId = 1)
        {
            string link = "api/WebCategories/" + encrypt(String.Format("?settingId={0}&serverPassword=123", settingId));
            var response = await client.GetAsync(link);
            if (response.IsSuccessStatusCode)
            {
                var ret = response.Content.ReadAsStringAsync();
                var temp = JsonConvert.DeserializeObject<List<CategoryM>>(ret.Result);
                return temp;
            }
            return null;
        }
    }
}
