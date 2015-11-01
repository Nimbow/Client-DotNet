using System;
using System.Diagnostics.Contracts;

namespace Nimbow.Api.Client.Http
{
    internal sealed class NimbowApiClientHttpSyncWrapper : IDisposable
    {
        #region Init

        private bool _disposed;
        private readonly Lazy<NimbowApiClientHttpAsyncWrapper> _asyncWrapper;

        public NimbowApiClientHttpSyncWrapper()
        {
            _asyncWrapper = new Lazy<NimbowApiClientHttpAsyncWrapper>(() => new NimbowApiClientHttpAsyncWrapper());
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~NimbowApiClientHttpSyncWrapper()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_asyncWrapper.IsValueCreated)
                    {
                        _asyncWrapper.Value.Dispose();
                    }
                }

                _disposed = true;
            }
        }

        #endregion

        #region Methods

        public SendSmsResponse SendSms(SendSmsRequest request)
        {
            Contract.Requires(request != null);
            Contract.Ensures(Contract.Result<SendSmsResponse>() != null);

            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(NimbowApiClientHttpSyncWrapper));
            }

            return _asyncWrapper.Value.SendSmsAsync(request).Result;
        }

        #endregion
    }
}