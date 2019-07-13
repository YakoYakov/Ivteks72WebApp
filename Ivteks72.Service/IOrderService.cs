namespace Ivteks72.Service
{   
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ivteks72.Domain;
    using Ivteks72.Domain.Enums;

    public interface IOrderService
    {
        Task CreateOrder(Clothing clothing, string issuerId);

        List<TOrderViewModel> GetOrdersByStatus<TOrderViewModel>(OrderStatus status, string username);

        List<TOrderViewModel> GetAllOrdersSortedByUserThenByCompany<TOrderViewModel>();

        TOrderViewModel GetOrderById<TOrderViewModel>(string id);

        Task EditOrderStatus(string id,string newStatus);
    }
}
