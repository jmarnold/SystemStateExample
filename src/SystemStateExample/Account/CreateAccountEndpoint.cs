using System.Net.Mail;
using SystemStateExample.Infrastructure;
using FubuMVC.Core.Continuations;

namespace SystemStateExample.Account
{
    public class CreateAccountEndpoint
    {
        private readonly IEmailGateway _gateway;

        public CreateAccountEndpoint(IEmailGateway gateway)
        {
            _gateway = gateway;
        }

        public FubuContinuation post_register(CreateAccount input)
        {
            var message = CreateMessage(input);
            _gateway.Send(message);

            return FubuContinuation.RedirectTo(new WelcomeMessage
            {
                Name = input.Name
            });
        }

        public virtual MailMessage CreateMessage(CreateAccount account)
        {
            var message = new MailMessage();
            message.To.Add(account.EmailAddress);
            message.Subject = "Welcome!";
            message.Body = "Thank you for signing up!";

            return message;
        }
    }
}