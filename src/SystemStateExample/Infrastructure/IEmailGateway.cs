using System.Net.Mail;

namespace SystemStateExample.Infrastructure
{
    public interface IEmailGateway
    {
        void Send(MailMessage message);
    }
}