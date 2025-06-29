using System;
using System.Threading.Tasks;
using TriNet.TestApp.Otp;
using System.Dynamic;
using System.Collections.Generic;

namespace TriNet.TestApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            dynamic payload = new System.Dynamic.ExpandoObject();
            dynamic info = new System.Dynamic.ExpandoObject();
            info.ip = "172.34.09.00";
            payload.mobile = "9876543210";
            payload.channel = "sms";
            payload.info= info;
            var message = await new SendOtp().AddPayload(payload).Get();
            Console.WriteLine(message);
        }
    }
}
