namespace Ivteks72.Service.Sender
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class EmailSender : ISender
    {
        private readonly string host;
        private readonly int port;
        private readonly bool enableSSL;
        private readonly string username;
        private readonly string password;

        public EmailSender(string host, int port, bool enableSSL, string username, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.username = username;
            this.password = password;
        }

        public Task SendMessageAsync(string email, string subject, string message)
        {
            var client = new SmtpClient(this.host, this.port)
            {
                Credentials = new NetworkCredential(this.username, this.password),
                EnableSsl = this.enableSSL
            };

            return client.SendMailAsync(new MailMessage(this.username, email, subject, message) { IsBodyHtml = true });
        }
    }
}
