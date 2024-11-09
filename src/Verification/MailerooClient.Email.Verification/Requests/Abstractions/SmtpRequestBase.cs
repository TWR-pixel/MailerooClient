using System.Net.Http;

namespace MailerooClient.Email.Verification.Requests.Abstractions
{
    public abstract class SmtpRequestBase<TResponse> : RequestBase<TResponse> where TResponse : class
    {
        protected SmtpRequestBase(string methodName, HttpMethod httpMethod) : base(methodName, httpMethod, "https://smtp.maileroo.com")
        {
        }
    }
}
