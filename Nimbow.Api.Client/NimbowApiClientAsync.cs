using System.Threading.Tasks;
using Nimbow.Api.Client.Http;

namespace Nimbow.Api.Client
{
    public sealed class NimbowApiClientAsync : INimbowApiClientAsync
    {
        public async Task<SendSmsResult> SendSmsAsync(Sms sms)
        {
            using (var client = new NimbowApiClientHttpAsyncWrapper())
            {
                var request = sms.ToSendSmsRequest();
                var response = await client.SendSmsAsync(request);

                return SendSmsResult.FromSmsResponse(response);
            }
        }
    }
}