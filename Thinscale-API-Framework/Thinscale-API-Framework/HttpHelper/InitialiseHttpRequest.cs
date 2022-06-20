using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Thinscale_API_Framework.HttpHelper
{
    public class InitialiseHttpRequest
    {
        public static async Task<string> InitiateRequest(HttpMethod method, string uri = null, string accessToken = null,
            string jsonRequest = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK, Dictionary<string, string> formContent = null)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = method;
                request.RequestUri = new Uri(uri);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                if (jsonRequest != null)
                {
                    request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                }

                else if (formContent != null)
                {
                    request.Content = new FormUrlEncodedContent(formContent);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                }

                var response = await client.SendAsync(request).ConfigureAwait(false);
                var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.StatusCode != expectedStatusCode)
                {
                    throw new WebException($"Request failed. Status code: {response.StatusCode}. JSON: {jsonResponse}");
                }

                return jsonResponse;
            }
        }
    }
}
