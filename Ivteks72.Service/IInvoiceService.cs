
namespace Ivteks72.Service
{
    using System.Collections.Generic;

    using Ivteks72.Domain;

    public interface IInvoiceService
    {
        IEnumerable<TViewModel> GetAllInovoicesByUserName<TViewModel>(string username);
    }
}
