using MailerooClient.Email.Verification;
using MailerooClient.Email.Verification.Requests.Check;

namespace MailerooClient.Tests.Unit.Verification;

public class MailerooClientTests
{
    [Fact]
    public async Task SendRequestTest()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("X-API-KEY", "<YOU-API-KEY>");
        var options = new MailerooClientOptions(apiKey: "<YOUR-API-KEY>");
        var client = new MailerooApiClient(options: options, httpClient);


        var request = new CheckRequest(email: "iewofiweiofj@mafial.ru");

        CheckResponse? response = await client.SendRequestAsync(request);

        /*response
        {
            "success": true,
            "error_code": "",
            "message": "",
            "data": {
                "email": "iewofiweiofj@mafial.ru",
                "format_valid": "true",
                "mx_found": "false",
                "disposable": "false",
                "role": "false",
                "free": "false",
                "domain_suggestion": "mail.ru"
            }
        }
        */

    }

}
