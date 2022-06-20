using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Thinscale_API_Framework.JsonHelper
{
    public class JsonSchemaValidate
    {
        public static void ValidateJsonSchema(string schemaFields = null, string jsonResponse = null)
        {
            JSchema schema = JSchema.Parse(schemaFields);
            JObject fields = JObject.Parse(jsonResponse);
            bool valid = fields.IsValid(schema);
        }
    }
}
