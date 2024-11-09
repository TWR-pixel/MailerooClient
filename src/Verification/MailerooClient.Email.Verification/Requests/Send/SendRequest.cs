using MailerooClient.Email.Verification.Requests.Abstractions;
using System.Net.Http;

namespace MailerooClient.Email.Verification.Requests.Send
{
    public class SendRequest : SmtpRequestBase<SendResponse>
    {
        public SendRequest(string from, string to, string subject, string html = "") : base("send", HttpMethod.Post)
        {
            From = from;
            To = to;
            Subject = subject;
            Html = html;
        }


        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string? Html { get; set; }

        public override HttpContent ToHttpContent()
        {
            var content = new MultipartFormDataContent
            {
                { new StringContent(From), "from" },
                { new StringContent(To), "to" },
                { new StringContent(Subject), "subject" },
                { new StringContent(Html), "html" },
            };

            return content;
        }
    }
}
