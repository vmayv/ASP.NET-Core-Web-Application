using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class PostHandler
    {
        private static HttpClient _httpClient = new HttpClient();

        public async Task<Post> GetPostAsync(string uri, int id)
        {
            var response = await _httpClient.GetAsync($"{uri}{id}");

            if(!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Post>(content);

            return result;
        }
    }
}
