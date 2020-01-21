using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace NaniWeb.Services
{
    public class EmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration) => _configuration = configuration;

        public async Task SendEmail(string origin, string destination, string subject, string message, string htmlMessage)
        {
            if (!_configuration.GetValue<bool>("Email:Enabled"))
                return;

            var mimeMessage = new MimeMessage();
            var bodyBuilder = new BodyBuilder();

            mimeMessage.From.Add(new MailboxAddress(_configuration.GetValue<string>("Web:SiteName"), origin));
            mimeMessage.To.Add(new MailboxAddress(destination));
            mimeMessage.ReplyTo.Add(new MailboxAddress(destination));

            mimeMessage.Subject = subject;
            bodyBuilder.TextBody = message;
            bodyBuilder.HtmlBody = htmlMessage;

            using var smtpClient = new SmtpClient
            {
                ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };

            await smtpClient.ConnectAsync(_configuration.GetValue<string>("Email:SmtpServer"), _configuration.GetValue<int>("Email:SmtpServerPort"));

            if (string.IsNullOrEmpty(_configuration.GetValue<string>("Email:SmtpServerUser")))
                await smtpClient.AuthenticateAsync(_configuration.GetValue<string>("Email:SmtpServerUser"), _configuration.GetValue<string>("Email:SmtpServerPassword"));

            await smtpClient.SendAsync(mimeMessage);
            await smtpClient.DisconnectAsync(true);
        }
    }
}