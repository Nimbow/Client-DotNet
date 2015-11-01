using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Nimbow.Api.Client
{
    [ContractClass(typeof(NimbowApiClientAsyncContracts))]
    public interface INimbowApiClientAsync
    {
        Task<SendSmsResult> SendSmsAsync(Sms sms);
    }

    [ContractClassFor(typeof(INimbowApiClientAsync))]
    internal abstract class NimbowApiClientAsyncContracts : INimbowApiClientAsync {
        public Task<SendSmsResult> SendSmsAsync(Sms sms)
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<Task<SendSmsResult>>() != null);

            return default(Task<SendSmsResult>);
        }
    }
}