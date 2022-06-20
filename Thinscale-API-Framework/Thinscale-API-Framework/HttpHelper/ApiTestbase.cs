using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Thinscale_API_Framework.JsonHelper;

namespace Thinscale_API_Framework.HttpHelper
{
    public class ApiTestbase
    {
        public static async Task<T> MakeGetRequestAsync<T>(string uri, string accessToken = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK,
           bool validateSchema = false, string schemaFields = null)
        {
            var jsonResponse = await MakeApiCallAsync(uri, HttpMethod.Get, accessToken, expectedStatusCode: expectedStatusCode, schemaFields: schemaFields,
                validateSchema: validateSchema).ConfigureAwait(false);

            return jsonResponse.FromJson<T>(JsonExtensions.DefaultSettings);
        }

        public static async Task<Response> MakePostRequestAsync<Request, Response>(string uri, Request resource, string accessToken = null, HttpStatusCode expectedStatusCode = HttpStatusCode.Created)
        {
            var jsonRequest = resource.ToJson(JsonExtensions.DefaultSettings);
            var jsonResponse = await MakeApiCallAsync(uri, HttpMethod.Post, accessToken, jsonRequest, expectedStatusCode).ConfigureAwait(false);
            return jsonResponse.FromJson<Response>(JsonExtensions.DefaultSettings);
        }

        public static async Task<string> MakeApiCallAsync(string uri, HttpMethod method, string accessToken, string jsonRequest = null,
           HttpStatusCode expectedStatusCode = HttpStatusCode.OK, bool validateSchema = false, string schemaFields = null, Dictionary<string, string> formContent = null)
        {
            var jsonResponse = await InitialiseHttpRequest.InitiateRequest(method: method, uri: uri, accessToken: accessToken,
                jsonRequest: jsonRequest, expectedStatusCode: expectedStatusCode, formContent: formContent);

            if (validateSchema == true)
            {
                JsonSchemaValidate.ValidateJsonSchema(schemaFields, jsonResponse.ToString());
            }

            return jsonResponse;
        }

    }
}