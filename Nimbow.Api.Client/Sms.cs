using System.Configuration;
using System.Diagnostics.Contracts;
using Nimbow.Api.Client.Http;

namespace Nimbow.Api.Client
{
    public abstract partial class Sms
    {
        internal Sms()
        {
            // no inheritance from outside of the assembly
            From = ConfigurationManager.AppSettings["Nimbow.Api.Default.From"];
        }

        public string From { get; set; }

        public string To { get; set; }

        internal virtual SendSmsRequest ToSendSmsRequest()
        {
            Contract.Ensures(Contract.Result<SendSmsRequest>() != null);

            return new SendSmsRequest {From = From, To = To};
        }
    }
}