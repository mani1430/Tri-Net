using System.Dynamic;
using TriNet.TestApp.Otp.Support;

namespace TriNet.TestApp.Otp
{
    public class SendOtp : OtpBase
    {
        protected override string ApiRoute => "/otp/send";

        public SendOtp()
        {
            dynamic DefaultPayload = new ExpandoObject();
            DefaultPayload.name = "mani";

            dynamic DefaultHeaders = new ExpandoObject();
            DefaultHeaders.Accept = "application/json";
            DefaultHeaders.ContentType = "application/json";
        }
    }
}
