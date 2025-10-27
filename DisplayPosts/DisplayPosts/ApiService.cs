using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DisplayPosts

{
    internal class ApiService
    {
        private static readonly HttpClient http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        private const string Endpoint = "https://jsonplaceholder.typicode.com/posts";

        public async Task<List<Post>> GetListAsync(CancellationToken ct = default)
        {
            try
            {
                var json = await http.GetStringAsync(Endpoint);
                return JsonConvert.DeserializeObject<List<Post>>(json) ?? new List<Post>();
            }

            catch {
                return new List<Post>();
                }


        }


    }
}
