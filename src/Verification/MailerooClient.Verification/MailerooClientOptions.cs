namespace MailerooClient.Verification
{
    public sealed class MailerooClientOptions
    {
        public string Token { get; set; }
        public string BaseUrl { get; private set; } = "https://verify.maileroo.net";

        public MailerooClientOptions(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new System.ArgumentException($"\"{nameof(token)}\" cannot be empty or contain only space.", nameof(token));

            Token = token;
        }
    }
}
