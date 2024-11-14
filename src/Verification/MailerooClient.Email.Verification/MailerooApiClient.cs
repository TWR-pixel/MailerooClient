using MailerooClient.Email.Verification.Exceptions;
using MailerooClient.Email.Verification.Requests.Abstractions;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MailerooClient.Email.Verification
{
    public class MailerooApiClient :  IApiClient
    {
        #region Properties and fields
        public HttpStatusCode StatusCode { get; private set; }

        protected HttpClient Client { get; private set; }
        protected MailerooClientOptions Options { get; private set; }
        #endregion

        #region Constructor
        public MailerooApiClient(MailerooClientOptions options, HttpClient? client = null)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));

            if (client != null)
            {
                Client = client;

                if (!client.DefaultRequestHeaders.Contains("X-API-KEY"))
                    throw new XApiKeyHeaderNotFountException();

                Client.DefaultRequestHeaders.Add("X-API-KEY", options.ApiKey);
            }
            else
            {
                Client = new HttpClient();
                Client.DefaultRequestHeaders.Add("X-API-KEY", options.ApiKey);
            }
        }

        #endregion

        #region Methods
        public async Task<TResponse> SendRequestAsync<TResponse>(RequestBase<TResponse> request,
                                                                 CancellationToken cancellationToken = default) where TResponse : class
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var requestUri = $"{request.BaseUrl}/{request.MethodName}";
            var req = new HttpRequestMessage(request.HttpMethod, requestUri)
            {
                Content = request.ToHttpContent()
            };

            var httpResponse = await Client.SendAsync(req, cancellationToken);

            StatusCode = httpResponse.StatusCode;

            var response = JsonSerializer.Deserialize<TResponse>(await httpResponse.Content.ReadAsStreamAsync());

            return response is null ? throw new NullReferenceException() : response;
        }

        public void Dispose() => Client.Dispose();

        public async ValueTask DisposeAsync() => await new ValueTask(Task.Run(() => Client.Dispose()));
        #endregion

    }
}
