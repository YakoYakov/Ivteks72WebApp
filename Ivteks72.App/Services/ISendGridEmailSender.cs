namespace Ivteks72.App.Services
{
    using System.Threading.Tasks;

    public interface ISendGridEmailSender
    {
        Task SendConfirmatioEmailAsync(string email, string subject, string htmlMessage);

        Task SendContactFormEmailAsync(string email, string subject, string htmlMessage);
    }
}
