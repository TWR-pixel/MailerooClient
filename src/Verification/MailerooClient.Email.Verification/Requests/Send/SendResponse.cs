using System.Text.Json.Serialization;

namespace MailerooClient.Email.Verification.Requests.Send
{
    public class SendResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
