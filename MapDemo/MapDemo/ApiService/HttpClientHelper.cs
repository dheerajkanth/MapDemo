using MapDemo.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MapDemo.ApiService
{
    public class HttpClientHelper
    {
        public static async Task<RootObject> GetWeatherDataByZipCode(string pQueryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(pQueryString).ConfigureAwait(false);
            RootObject data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                data = JsonConvert.DeserializeObject<RootObject>(json);
            }
            return data;
        }
    }
}
