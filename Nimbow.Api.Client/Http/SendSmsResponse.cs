namespace Nimbow.Api.Client.Http
{
    internal sealed class SendSmsResponse
    {
        public SendSmsStatusCode StatusCode { get; set; }

        public string MessageId { get; set; }

        public int? MessageParts { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public decimal? NetCost { get; set; }
    }
}