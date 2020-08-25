using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// A class that handles the API request
    /// </summary>
    public class ApiReader
    {
        /// <summary>
        /// Reads the JSON string from the API, formats it and returns a list a data on it
        /// </summary>
        /// <param name="url">The link to the API</param>
        /// <returns>The returned list of data</returns>
        public static async Task<List<ArticleUsers>> GetRequest(string url)
        {
            List<ArticleUsers> toReturn = new List<ArticleUsers>();

            using HttpClient client = new HttpClient();

            for (int i = 1; i <= 2; i++)
            {
                string uri = url + i;
                using HttpResponseMessage response = await client.GetAsync(uri);
                using HttpContent content = response.Content;
                var myContent = await content.ReadAsStringAsync();
                var value = JsonSerializer.Deserialize<Root>(myContent);
                toReturn.AddRange(value.data);
            }
            return toReturn;
        }
    }
}