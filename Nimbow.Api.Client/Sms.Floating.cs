using System;
using System.Threading.Tasks;

namespace Nimbow.Api.Client
{
    partial class Sms
    {
        public static TextSms CreateText()
        {
            return new TextSms();
        }

        public static BinarySms CreateBinary()
        {
            return new BinarySms();
        }
    }

    public static class SmsExtensions
    {
        private static readonly Lazy<NimbowApiClientAsync> ApiClientAsync = new Lazy<NimbowApiClientAsync>(() => new NimbowApiClientAsync());

        private static TSms Assign<TSms>(this TSms sms, Action<TSms> assigner)
        {
            assigner.Invoke(sms);
            return sms;
        }

        public static Task<SendSmsResult> SendAsync<TSms>(this TSms sms)
            where TSms : Sms
        {
            return ApiClientAsync.Value.SendSmsAsync(sms);
        }

        public static TSms From<TSms>(this TSms sms, string from)
            where TSms : Sms
        {
            return sms.Assign(s => s.From = from);
        }

        public static TSms To<TSms>(this TSms sms, string to)
            where TSms : Sms
        {
            return sms.Assign(s => s.To = to);
        }

        public static TextSms Text(this TextSms textSms, string text)
        {
            return textSms.Assign(s => s.Text = text);
        }

        public static BinarySms Data(this BinarySms binarySms, byte[] data)
        {
            return binarySms.Assign(s => s.Data = data);
        }
    }
}