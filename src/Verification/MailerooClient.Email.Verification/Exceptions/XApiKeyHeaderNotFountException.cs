using System;

namespace MailerooClient.Email.Verification.Exceptions
{
    public class XApiKeyHeaderNotFountException : Exception
    {
        public XApiKeyHeaderNotFountException() : base("X-API-KEY doesn't exists in the headers")
        {
        }


    }
}
