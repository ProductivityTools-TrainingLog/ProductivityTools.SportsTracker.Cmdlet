using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.SportsTracker.App
{
    public class Application
    {
        private string Address = "https://api.sports-tracker.com/apiserver/v1/login";

        public async Task Login(string login, string password)
        {
            var client = new HttpClient(new LoggingHandler(new HttpClientHandler()));
            Uri url = new Uri(Address);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var formContent = new FormUrlEncodedContent(new[]
{
    new KeyValuePair<string, string>("l", login),
    new KeyValuePair<string, string>("p", password)
});

            var anonymous = new { l = login, p = password };
            var dataAsString = JsonConvert.SerializeObject(anonymous);
            var content = new StringContent(dataAsString, Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await client.PostAsync(url, formContent); ;
            var x = response.Content.ReadAsStringAsync();;
            var xxx=x.Result;
        }
    }
}

