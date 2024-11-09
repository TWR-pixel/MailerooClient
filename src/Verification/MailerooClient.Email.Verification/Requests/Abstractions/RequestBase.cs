using System.Net.Http;
using System.Text.Json.Serialization;

namespace MailerooClient.Email.Verification.Requests.Abstractions
{
    public abstract class RequestBase<TResponse> where TResponse : class
    {
        public RequestBase(string methodName, HttpMethod httpMethod, string baseUrl)
        {
            MethodName = methodName ?? throw new System.ArgumentNullException(nameof(methodName));
            HttpMethod = httpMethod ?? throw new System.ArgumentNullException(nameof(httpMethod));
            BaseUrl = baseUrl ?? throw new System.ArgumentNullException(nameof(baseUrl));
        }

        [JsonIgnore]
        public string BaseUrl { get; set; }

        [JsonIgnore]
        public string MethodName { get; private set; }

        [JsonIgnore]
        public HttpMethod HttpMethod { get; set; }

        public abstract HttpContent ToHttpContent();
    }
}
