using System;

namespace MailerooClient.Email.Verification
{
    public sealed class MailerooClientOptions
    {
        public string ApiKey { get; set; }

        public MailerooClientOptions(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException($"\"{nameof(apiKey)}\" cannot be empty or contain only space.", nameof(apiKey));

            ApiKey = apiKey;
        }
    }
}
