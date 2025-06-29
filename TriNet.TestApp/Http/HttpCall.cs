using System.Net.Http;
using System.Threading.Tasks;
using System.Dynamic;
using System.Text;
using System.Text.Json;

namespace TriNet.TestApp.Http
{
    public abstract class HttpCall : TriNetBase
    {
        public string FormFullUrl()
        {
            if (!string.IsNullOrWhiteSpace(ApiPath))
            {
                return ApiPath;
            }

            if (!string.IsNullOrWhiteSpace(ApiBaseUri) && !string.IsNullOrWhiteSpace(ApiRoute))
            {
                return ApiBaseUri + ApiRoute;
            }

            throw new InvalidOperationException("Api path is missing!");
        }

                public HttpCall AddPayload(dynamic payload)
        {
            if (payload == null) return this;

            var targetDict = (IDictionary<string, object>)_payload;

            foreach (var prop in (IDictionary<string, object>)payload)
            {
                targetDict[prop.Key] = prop.Value;
            }

            return this;
        }

        // Merges default + user-provided
        private IDictionary<string, object> GetMergedPayload()
        {
            var merged = new ExpandoObject() as IDictionary<string, object>;

            foreach (var pair in (IDictionary<string, object>)DefaultPayload)
                merged[pair.Key] = pair.Value;

            foreach (var pair in (IDictionary<string, object>)_payload)
                merged[pair.Key] = pair.Value;

            return merged;
        }


        public HttpCall AddHeader(Dictionary<string, object> headers = null)
        {
            _headers = headers;
            return this;
        }

        public async Task<string> Get()
        {
            var FullUrl = FormFullUrl();
            Dd(GetMergedPayload());
            return FullUrl;
        }
    }
}
