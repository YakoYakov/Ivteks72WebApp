namespace Ivteks72.Service.Sender
{
    using System;
    using System.Threading.Tasks;

    public class EmailSender : ISender
    {
        public Task SendMessageAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
