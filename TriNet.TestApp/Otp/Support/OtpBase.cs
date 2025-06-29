using TriNet.TestApp.Http;

namespace TriNet.TestApp.Otp.Support
{
    public abstract class OtpBase : HttpCall
    {
        protected override string ApiBaseUri => "https://example.com";
    }
}