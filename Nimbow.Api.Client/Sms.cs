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
            GetMessageId = GetBoolSetting("Nimbow.Api.Default.GetMessageId");
            GetMessageParts = GetBoolSetting("Nimbow.Api.Default.GetMessageParts");
            GetFrom = GetBoolSetting("Nimbow.Api.Default.GetFrom");
            GetTo = GetBoolSetting("Nimbow.Api.Default.GetTo");
            GetNetCost = GetBoolSetting("Nimbow.Api.Default.GetNetCost");
        }

        private static bool GetBoolSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            return !string.IsNullOrEmpty(value) && bool.Parse(value);
        }

        public string From { get; set; }

        public string To { get; set; }

        public bool Test { get; set; }

        public bool GetMessageId { get; set; }

        public bool GetMessageParts { get; set; }

        public bool GetFrom { get; set; }

        public bool GetTo { get; set; }

        public bool GetNetCost { get; set; }

        internal virtual SendSmsRequest ToSendSmsRequest()
        {
            Contract.Ensures(Contract.Result<SendSmsRequest>() != null);

            return new SendSmsRequest
            {
                From = From,
                To = To,
                Test = Test,
                GetMessageId = GetMessageId,
                GetMessageParts = GetMessageParts,
                GetFrom = GetFrom,
                GetTo = GetTo,
                GetNetCost = GetNetCost
            };
        }
    }
}