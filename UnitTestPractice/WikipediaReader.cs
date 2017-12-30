using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnitTestPractice
{
    public class WikipediaReader
    {
        const string BASE_API_URI = @"https://en.wikipedia.org/w/api.php";
        const string ACTION = @"action";
        const string FORMAT = @"format";
        const string LIST = @"list";
        const string SEARCH_TERM = @"srsearch";

        private Dictionary<string, string> _parameters;

        public WikipediaReader()
        {
            _parameters = new Dictionary<string, string>();
        }

        public async Task<WikipediaSearchResult> SearchTitles(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException(nameof(query), "The parameter cannot be null.");
            }

            _parameters.Clear();
            _parameters.Add(ACTION, "query");
            _parameters.Add(FORMAT, "json");
            _parameters.Add(LIST, "search");
            _parameters.Add(SEARCH_TERM, "intitle:" + query);

            var response = await GetData();

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<WikipediaSearchResult>(json);
            return result;
        }

        private async Task<HttpResponseMessage> GetData()
        {
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(mediaType);
            client.DefaultRequestHeaders.Add("User-Agent", "Drew Morgan Test Wikipedia Reader");

            var content = new FormUrlEncodedContent(_parameters);
            return await client.PostAsync(BASE_API_URI, content);
        }
    }
}