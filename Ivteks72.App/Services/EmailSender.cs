namespace Ivteks72.App.Services
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.Extensions.Options;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks;

    public class EmailSender : ISendGridEmailSender
    {
        public EmailSender(IOptions<MessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public MessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendContactFormEmailAsync(string email, string subject, string message)
        {
            return ContactFormEmailExecute(Options.SendGridKey, subject, message, email);
        }

        public Task ContactFormEmailExecute(string apiKey, string subject, string message, string email)
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

        public Task SendConfirmatioEmailAsync(string email, string subject, string message)
        {
            return ConfirmationEmailExecute(Options.SendGridKey, subject, message, email);
        }

        public Task ConfirmationEmailExecute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("ivteks72@ivteks72.bg", "Petyr Ivanov"),
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
