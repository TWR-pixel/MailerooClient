using MailerooClient.Verification;
using MailerooClient.Verification.Requests.Check;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

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