using MailerooClient.Email.Verification.Requests.Abstractions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailerooClient.Email.Verification.Requests.Check
{
    public sealed class CheckRequest : VerifyRequestBase<CheckResponse>
    {
        public CheckRequest(string email) : base("check", HttpMethod.Post)
        {
            Email = email;
        }

        [JsonPropertyName("email_address")]
        public string Email { get; set; }

        public override HttpContent ToHttpContent()
        {
            var json = JsonSerializer.Serialize(this);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return content;
        }
    }
}
