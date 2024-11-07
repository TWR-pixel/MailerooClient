using MailerooClient.Verification.Requests.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MailerooClient.Verification
{
    public sealed class MailerooApiClient
    {
        private readonly HttpClient _client;
        private readonly MailerooClientOptions _options;

        public MailerooApiClient(MailerooClientOptions options, HttpClient? client = null)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));

            if (client != null)
            {
                _client = client;

                if (!client.DefaultRequestHeaders.Contains("X-API-KEY"))
                    throw new KeyNotFoundException("X-API-KEY not found or it is empty");

                _client.DefaultRequestHeaders.Add("X-API-KEY", options.Token);
            }
            else
            {
                _client = new HttpClient();
                _client.DefaultRequestHeaders.Add("X-API-KEY", options.Token);
            }

        }

        public async Task<TResponse> SendRequestAsync<TResponse>(RequestBase<TResponse> request,
                                                                 CancellationToken cancellationToken = default) where TResponse : class
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var requestUri = $"{_options.BaseUrl}/{request.MethodName}";
            var httpResponse = await _client.PostAsync(requestUri, request.ToHttpContent(), cancellationToken);

            var response = JsonSerializer.Deserialize<TResponse>(await httpResponse.Content.ReadAsStreamAsync());

            return response is null ? throw new NullReferenceException() : response;
        }
    }
}
