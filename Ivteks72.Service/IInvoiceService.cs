
namespace Ivteks72.Service
{
    using System.Collections.Generic;

    using Ivteks72.Domain;

    public interface IInvoiceService
    {
        List<Invoice> GetAllInovoicesByUserName(string username);
    }
}
