using System.Threading.Tasks;

using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;


namespace LR2.Services
{
    public class EmailMessageSender: IEmailSender
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;

        public EmailMessageSender(IConfiguration config)
        {
            _smtpServer = config["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(config["EmailSettings:SmtpPort"]);
            _smtpUser = config["EmailSettings:SmtpUser"];
            _smtpPass = config["EmailSettings:SmtpPass"];
        }

        public async Task SendEmailAsync(string name, string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(name, _smtpUser));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpUser, _smtpPass);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
