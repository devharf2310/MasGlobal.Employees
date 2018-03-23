using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasGlobal.Employees.DAL
{
    public class DefaultHttpClient : IHttpClient
    {
        public async Task<IEnumerable<T>> GetAsync<T>(string uri) where T : class
        {
            return await GetAsync<T>(new Uri(uri));
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Uri uri) where T : class
        {
            var result = default(IEnumerable<T>);

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri).ConfigureAwait(false);

                if (response.Content.Headers.ContentLength.GetValueOrDefault() <= 0)
                    return null;

                string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<IEnumerable<T>>(responseBody);
            }
            return result;
        }
    }
}
