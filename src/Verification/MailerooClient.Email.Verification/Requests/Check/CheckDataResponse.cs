using System.Text.Json.Serialization;

namespace MailerooClient.Email.Verification.Requests.Check
{
    public sealed class CheckDataResponse
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("format_valid")]
        public bool FormatValid { get; set; }

        [JsonPropertyName("mx_found")]
        public bool MxFound { get; set; }

        [JsonPropertyName("disposable")]
        public bool Disposable { get; set; }

        [JsonPropertyName("role")]
        public bool Role { get; set; }

        [JsonPropertyName("free")]
        public bool Free { get; set; }

        [JsonPropertyName("domain_suggestion")]
        public string DomainSuggestion { get; set; } = string.Empty;
    }
}
