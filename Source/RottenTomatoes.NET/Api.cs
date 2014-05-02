using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RottenTomatoes
{
    internal static class Api
    {
        public static string LastUrlCalled;

        private static async Task<T> QueryAsync<T>(string endpoint, string apiKey)
        {
            var client = new HttpClient();
            var url = endpoint.AppendApiKey(apiKey);
           
            var result = await client.GetAsync(url);
            var jsonObjects = await result.Content.ReadAsStringAsync();
            var deserializedObjects = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(jsonObjects));

            LastUrlCalled = url; 

            return deserializedObjects;
        }

        internal static async Task<T> QueryAsync<T>(RottenTomatoesQuery<T> query,string apiKey)
        {
            return await QueryAsync<T>(query.Url, apiKey);
        }

        private static string AppendApiKey(this string url, string apiKey)
        {
            var newUrl = url.AppendQueryParameter("apiKey", apiKey);
            return newUrl;
        }

    }
}
