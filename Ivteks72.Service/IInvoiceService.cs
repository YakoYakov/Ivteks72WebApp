
namespace Ivteks72.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInvoiceService
    {
        IEnumerable<TViewModel> GetAllInovoicesByUserId<TViewModel>(string id);

        IEnumerable<TViewModel> GetAllInovoices<TViewModel>();

        TViewModel GetInvoiceById<TViewModel>(string id);

        Task CreateInvoiceAsync(string userId, string clothingId, string orderId);
    }
}
