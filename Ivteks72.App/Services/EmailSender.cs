namespace Ivteks72.App.Services
{
    using System.Threading.Tasks;
    using Ivteks72.Service;
    using Microsoft.Extensions.Options;

    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class EmailSender : ISendGridEmailSender
    {
        private readonly IVaultService _vaultService;
        public EmailSender(IVaultService vaultService)
        {
            _vaultService = vaultService;
        }

        public async Task SendContactFormEmailAsync(string email, string subject, string message)
        {
            var key = await _vaultService.GetSecretAsStringOrDefaultAsync("SendgridKey");
            await ContactFormEmailExecute(key, subject, message, email);
        }

        private Task ContactFormEmailExecute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(email),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message,
            };
            msg.AddTo(new EmailAddress("yako_iv@abv.bg", "Yako Yakov"));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }

        public async Task SendConfirmatioEmailAsync(string email, string subject, string message)
        {
            var key = await _vaultService.GetSecretAsStringOrDefaultAsync("SendgridKey");

            await ConfirmationEmailExecute(key, subject, message, email);
        }

        private Task ConfirmationEmailExecute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("ivteks72@ivteks72.bg", "Ivteks72"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message,
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }

    }
}
