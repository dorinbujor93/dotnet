using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleTestApp
{
    class Program
    {
       


        static async Task Main(string[] args)
        {
            const string baseUrl = "http://localhost:5005";

            //single instance
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(baseUrl);
            HttpResponseMessage response = await httpClient.GetAsync("api/hotels/1");
            var data = await response.Content.ReadAsStringAsync();
            Console.WriteLine(data);
        }
       
    }

    public class HotelsApiClient
    {
        private readonly HttpClient client;

        public HotelsApiClient(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri("http://localhost:5005");

            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }


        public async Task<HotelModel> GetHotel(int id)
        {
            var response = await this.client.GetAsync($"api/hotels/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<HotelModel>(result);
        }

        public class HotelModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
        }
    }
}
