using System.Text.Json.Serialization;

namespace MailerooClient.Email.Verification.Requests.Check
{
    public sealed class CheckResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error_code")]
        public string? ErrorCode { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public CheckDataResponse? Data { get; set; }
    }
}
