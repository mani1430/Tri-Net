using System.Dynamic;

namespace TriNet.TestApp.Http
{
    public abstract class TriNetBase
    {
        protected virtual string ApiBaseUri => "";
        protected virtual string ApiRoute => "";
        public virtual string ApiPath { get; set; }
        protected dynamic DefaultPayload = new ExpandoObject();
        protected dynamic _payload = new ExpandoObject();
        protected dynamic DefaultHeaders = new ExpandoObject();
        protected dynamic _headers = new ExpandoObject();
    }
}
