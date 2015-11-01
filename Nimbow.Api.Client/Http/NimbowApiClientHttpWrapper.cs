using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nimbow.Api.Client.Http
{
    internal sealed class NimbowApiClientHttpWrapper : IDisposable
    {
        #region Init

        private bool _disposed;
        private readonly HttpClient _httpClient;

        public NimbowApiClientHttpWrapper()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(GetAppSetting("Nimbow.Api.Url"), UriKind.Absolute),
                DefaultRequestHeaders = {{"X-Nimbow-API-Key", GetAppSetting("Nimbow.Api.Key")}}
            };
        }

        #endregion

        #region Helper

        private static string GetAppSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value)) throw new InvalidOperationException($"The appSetting \"{key}\" has not been set!");
            return value;
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~NimbowApiClientHttpWrapper()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }

                _disposed = true;
            }
        }

        #endregion

        #region Methods

        public async Task<SendSmsResponse> SendSmsAsync(SendSmsRequest request)
        {
            var httpResponse = await _httpClient.GetAsync(new Uri($"sms?{request.ToQueryParameterString()}", UriKind.Relative));

            httpResponse.EnsureSuccessStatusCode();

            var sendSmsResponse = await httpResponse.Content.ReadAsAsync<SendSmsResponse>();
            return sendSmsResponse;
        }

        #endregion
    }
}