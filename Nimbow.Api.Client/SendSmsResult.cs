using System.Diagnostics.Contracts;
using Nimbow.Api.Client.Http;

namespace Nimbow.Api.Client
{
    public sealed class SendSmsResult
    {
        public SendSmsStatusCode StatusCode { get; set; }

        public string MessageId { get; set; }

        public int? MessageParts { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public decimal? NetCost { get; set; }

        internal static SendSmsResult FromSmsResponse(SendSmsResponse sendSmsResponse)
        {
            Contract.Requires(sendSmsResponse != null);
            Contract.Ensures(Contract.Result<SendSmsResult>() != null);

            return new SendSmsResult
            {
                StatusCode = sendSmsResponse.StatusCode,
                MessageId = sendSmsResponse.MessageId,
                MessageParts = sendSmsResponse.MessageParts,
                From = sendSmsResponse.From,
                To = sendSmsResponse.To,
                NetCost = sendSmsResponse.NetCost
            };
        }
    }
}