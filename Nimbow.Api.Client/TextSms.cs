using System.Diagnostics.Contracts;
using Nimbow.Api.Client.Http;

namespace Nimbow.Api.Client
{
    public sealed class TextSms : Sms
    {
        public string Text { get; set; }

        internal override SendSmsRequest ToSendSmsRequest()
        {
            Contract.Ensures(Contract.Result<SendSmsRequest>() != null);

            var request= base.ToSendSmsRequest();
            // TODO: Unicode recognition
            request.Text = Text;
            return request;
        }
    }
}