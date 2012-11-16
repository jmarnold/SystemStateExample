using System.Net.Mail;

namespace SystemStateExample.Infrastructure
{
    public class EmailGateway : IEmailGateway
    {
        private readonly EmailSettings _settings;

        public EmailGateway(EmailSettings settings)
        {
            _settings = settings;
        }

        public void Send(MailMessage message)
        {
            message.From = new MailAddress(_settings.From);
            using (var client = new SmtpClient(_settings.Host, _settings.Port))
            {
                client.Send(message);
            }
        }
    }
}