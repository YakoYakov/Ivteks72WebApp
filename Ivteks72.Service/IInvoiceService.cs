
namespace Ivteks72.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInvoiceService
    {
        IEnumerable<TViewModel> GetAllInovoicesByUserName<TViewModel>(string username);

        IEnumerable<TViewModel> GetAllInovoices<TViewModel>();

        TViewModel GetInvoiceById<TViewModel>(string id);

        Task CreateInvoice(string userId, string clothingId, string orderId);
    }
}
