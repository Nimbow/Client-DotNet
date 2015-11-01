using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Nimbow.Api.Client.Http;

namespace Nimbow.Api.Client
{
    public sealed class NimbowApiClientAsync : INimbowApiClientAsync
    {
        public async Task<SendSmsResult> SendSmsAsync(Sms sms)
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<Task<SendSmsResult>>() != null);

            using (var client = new NimbowApiClientHttpWrapper())
            {
                var request = sms.ToSendSmsRequest();
                var response = await client.SendSmsAsync(request);

                return SendSmsResult.FromSmsResponse(response);
            }
        }
    }
}