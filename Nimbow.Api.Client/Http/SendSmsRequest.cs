using System.Collections.Generic;

namespace Nimbow.Api.Client.Http
{
    internal sealed class SendSmsRequest
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Text { get; set; }

        public string ClientRef { get; set; }

        public SmsType Type { get; set; }

        public bool IsFlash { get; set; }

        public bool Test { get; set; }

        public bool GetMessageId { get; set; }

        public bool GetMessageParts { get; set; }

        public bool GetFrom { get; set; }

        public bool GetTo { get; set; }

        public bool GetNetCost { get; set; }

        public bool GetDeliveryReport { get; set; }

        public string ToQueryParameterString()
        {
            return string.Join("&", ToQueryParameters());
        }

        private IEnumerable<string> ToQueryParameters()
        {
            if (Type != SmsType.Gsm) yield return $"type={Type:G}";
            if (!string.IsNullOrEmpty(From)) yield return $"from={From}";
            if (!string.IsNullOrEmpty(To)) yield return $"to={To}";
            yield return $"text={Text}";
            if (!string.IsNullOrEmpty(ClientRef)) yield return $"ClientRef={ClientRef}";
            if (Test) yield return "test=1";
            if (IsFlash) yield return "flash=1";
            if (GetMessageId) yield return "GetMessageId=1";
            if (GetMessageParts) yield return "GetMessageParts=1";
            if (GetFrom) yield return "GetFrom=1";
            if (GetTo) yield return "GetTo=1";
            if (!GetDeliveryReport) yield return "GetDeliveryReport=0";
            if (GetNetCost) yield return "GetNetCost=1";
        }
    }
}