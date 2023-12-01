using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using unversite.Models;

namespace unversite.Service
{
   
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Api
    {
        private string url = @"http://universities.hipolabs.com/search?country=";
        public HttpClient client { get; set; }

        public Api()
        {
            client = new HttpClient();
        }
        
        public async Task<List<Unversitet>> GetUnversite(string input)
        {
            string resultUrl;

            if (!string.IsNullOrEmpty(input))
            {
                resultUrl = $"{url}{input}";
            }
            else
            {
                resultUrl = url;
            }

            client.BaseAddress = new Uri(resultUrl);
            var response = await client.GetAsync(" ");
            var Json = await response.Content.ReadAsStringAsync();

            var DeJson = JsonSerializer.Deserialize<List<Unversitet>>(Json);

            return DeJson;
        }
        

        
    }


}
