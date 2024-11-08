using System.Net.Http;
using System.Text.Json.Serialization;

namespace MailerooClient.Email.Verification.Requests.Abstractions
{
    public abstract class RequestBase<TResponse> where TResponse : class
    {
        public RequestBase(string methodName, HttpMethod httpMethod)
        {
            MethodName = methodName ?? throw new System.ArgumentNullException(nameof(methodName));
            HttpMethod = httpMethod ?? throw new System.ArgumentNullException(nameof(httpMethod));
        }

        [JsonIgnore]
        public string MethodName { get; private set; }
        [JsonIgnore]
        public HttpMethod HttpMethod { get; set; }

        public abstract HttpContent ToHttpContent();
    }
}
