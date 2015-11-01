using Nimbow.Api.Client.Http;

namespace Nimbow.Api.Client
{
    public sealed class NimbowApiClient : INimbowApiClient
    {
        public SendSmsResult SendSms(Sms sms)
        {
            using (var client = new NimbowApiClientHttpSyncWrapper())
            {
                var request = sms.ToSendSmsRequest();
                var response = client.SendSms(request);

                return SendSmsResult.FromSmsResponse(response);
            }
        }
    }
}