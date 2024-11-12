using MailerooClient.Email.Verification.Requests.Abstractions;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace MailerooClient.Email.Verification
{
    public interface IApiClient : IDisposable, IAsyncDisposable
    {
        public Task<TResponse> SendRequestAsync<TResponse>(RequestBase<TResponse> request, CancellationToken cancellationToken = default) where TResponse : class;
    }
}
