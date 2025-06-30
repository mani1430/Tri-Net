using System.Dynamic;
using TriNet.TestApp.Otp;

namespace TriNet.TestApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var message = await new SendOtp().AddPayload(FormPayload()).Get();
            Console.WriteLine(message);
        }

        private static ExpandoObject FormPayload()
        {
            dynamic payload = new ExpandoObject();
            dynamic info = new ExpandoObject();
            info.ip = "172.34.09.00";
            payload.mobile = "9876543210";
            payload.channel = "sms";
            payload.info = info;
            return payload;
        }

        private static ExpandoObject FormHeaders()
        {
            dynamic header = new ExpandoObject();
            header.UserAgent = "Me";
            return header;
        }
    }
}
