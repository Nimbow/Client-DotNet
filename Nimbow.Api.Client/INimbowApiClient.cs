using System.Diagnostics.Contracts;

namespace Nimbow.Api.Client
{
    [ContractClass(typeof(NimbowApiClientContracts))]
    public interface INimbowApiClient
    {
        SendSmsResult SendSms(Sms sms);
    }

    [ContractClassFor(typeof(INimbowApiClient))]
    internal abstract class NimbowApiClientContracts : INimbowApiClient
    {
        public SendSmsResult SendSms(Sms sms)
        {
            Contract.Requires(sms != null);
            Contract.Ensures(Contract.Result<SendSmsResult>() != null);

            return default(SendSmsResult);
        }
    }
}