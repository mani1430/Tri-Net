using TriNet.TestApp.Otp.Support;

namespace TriNet.TestApp.Otp
{
    public class SendOtp : OtpBase
    {
        protected override string ApiRoute => "/otp/send";

        public SendOtp()
        {
            dynamic DefaultPayload = new System.Dynamic.ExpandoObject();
            DefaultPayload.name = "mani";
        }
    }
}
