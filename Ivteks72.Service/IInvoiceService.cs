
namespace Ivteks72.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInvoiceService
    {
        IEnumerable<TViewModel> GetAllInovoicesByUserName<TViewModel>(string username);

        Task CreateInvoice(string userId, string clothingId, string orderId);
    }
}
