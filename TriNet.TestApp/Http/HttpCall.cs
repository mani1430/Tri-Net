using System.Dynamic;

namespace TriNet.TestApp.Http
{
    public abstract class HttpCall : TriNetBase
    {
        public HttpCall()
        {
            FormPayload();
        }

        private void FormPayload()
        {
            if (DefaultPayload != null)
            {
                _payload = _payload != null
                    ? MergeExpandos(DefaultPayload, _payload)
                    : DefaultPayload;
            }
        }

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

        public HttpCall AddPayload(ExpandoObject payload)
        {
            if (payload == null) return this;

            _payload = payload;

            return this;
        }

        private ExpandoObject MergeExpandos(ExpandoObject first, ExpandoObject second)
        {
            var result = new ExpandoObject();
            var dictResult = (IDictionary<string, object>)result;

            foreach (var kv in (IDictionary<string, object>)first)
                dictResult[kv.Key] = kv.Value;

            foreach (var kv in (IDictionary<string, object>)second)
                dictResult[kv.Key] = kv.Value;

            return result;
        }


        public HttpCall AddHeader(ExpandoObject headers)
        {
            if (headers == null) return this;

            _headers = DefaultHeaders != null
                ? MergeExpandos(DefaultHeaders, headers)
                : headers;

            return this;
        }

        public async Task<string> Get()
        {
            var FullUrl = FormFullUrl();
            Dd(_payload, _headers);
            return FullUrl;
        }
    }
}
