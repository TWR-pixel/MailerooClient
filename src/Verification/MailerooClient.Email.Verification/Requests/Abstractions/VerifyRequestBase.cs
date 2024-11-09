using System.Net.Http;

namespace MailerooClient.Email.Verification.Requests.Abstractions
{
    public abstract class VerifyRequestBase<TResponse> : RequestBase<TResponse>
        where TResponse : class
    {
        protected VerifyRequestBase(string methodName, HttpMethod httpMethod) : base(methodName, httpMethod, "https://verify.maileroo.net")
        {
        }
    }
}
