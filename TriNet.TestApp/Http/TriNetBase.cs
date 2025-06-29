using System.Text;
using System.Text.Json;
using System.Dynamic;
using System.Collections.Generic;

namespace TriNet.TestApp.Http
{
    public abstract class TriNetBase
    {
        protected virtual string ApiBaseUri => null;
        protected virtual string ApiRoute => null;
        public virtual string ApiPath { get; set; }
        protected dynamic DefaultPayload = new ExpandoObject();
        protected dynamic _payload = new ExpandoObject();

        protected object _headers;
    }
}
