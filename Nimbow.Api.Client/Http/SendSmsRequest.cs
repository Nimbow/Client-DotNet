using System.Collections.Generic;

namespace Nimbow.Api.Client.Http
{
    internal sealed class SendSmsRequest
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Text { get; set; }

        public SmsType Type { get; set; }

        public bool Test { get; set; }

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
            if (Test) yield return "test=1";
        }
    }
}