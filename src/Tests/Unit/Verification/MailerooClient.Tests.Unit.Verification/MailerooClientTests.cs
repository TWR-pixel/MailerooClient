using MailerooClient.Email.Verification;
using MailerooClient.Email.Verification.Requests.Check;
using System.Diagnostics;

namespace MailerooClient.Tests.Unit.Verification;

public class MailerooClientTests
{
    [Fact]
    public async Task SendRequestTest()
    {
        var options = new MailerooClientOptions("<ENTER-YOUR-API-KEY-HERE>");
        var mailerooClient = new MailerooApiClient(options);
        var request = new CheckRequest("iewofiweiofj@mafial.ru");

        var resp = await mailerooClient.SendRequestAsync(request);

        Debug.WriteLine(resp);
    }
}