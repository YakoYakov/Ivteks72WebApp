namespace Ivteks72.Service.Sender
{
    using System.Threading.Tasks;

    public interface ISender
    {
        Task SendMessageAsync(string email, string subject, string message);
    }
}
