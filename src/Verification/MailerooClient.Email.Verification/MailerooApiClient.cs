using MailerooClient.Email.Verification.Requests.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MailerooClient.Email.Verification
{
    public class MailerooApiClient : IDisposable, IAsyncDisposable
    {
        #region Properties and fields
        protected HttpClient Client { get; private set; }
        protected MailerooClientOptions Options { get; private set; }

        private bool disposedValue;
        #endregion

        #region Constructor
        public MailerooApiClient(MailerooClientOptions options, HttpClient? client = null)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));


            if (client != null)
            {
                Client = client;

                if (!client.DefaultRequestHeaders.Contains("X-API-KEY"))
                    throw new KeyNotFoundException("X-API-KEY not found or it is empty");

                Client.DefaultRequestHeaders.Add("X-API-KEY", options.Token);
            }
            else
            {
                Client = new HttpClient();
                Client.DefaultRequestHeaders.Add("X-API-KEY", options.Token);
            }

        }

        #endregion

        #region Methods
        public async Task<TResponse> SendRequestAsync<TResponse>(RequestBase<TResponse> request,
                                                                 CancellationToken cancellationToken = default) where TResponse : class
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var requestUri = $"{Options.BaseUrl}/{request.MethodName}";
            var httpResponse = await Client.PostAsync(requestUri, request.ToHttpContent(), cancellationToken);

            var response = JsonSerializer.Deserialize<TResponse>(await httpResponse.Content.ReadAsStreamAsync());

            return response is null ? throw new NullReferenceException() : response;
        }

        public void Dispose()
        {
            Client.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await new ValueTask(Task.Run(() => Client.Dispose()));
        }
        #endregion

    }
}
