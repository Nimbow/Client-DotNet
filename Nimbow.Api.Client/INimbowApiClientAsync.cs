using System.Threading.Tasks;

namespace Nimbow.Api.Client
{
    public interface INimbowApiClientAsync
    {
        Task<SendSmsResult> SendSmsAsync(Sms sms);
    }
}