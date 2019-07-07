namespace Ivteks72.Service
{
    using Ivteks72.Domain;
    using Ivteks72.Domain.Enums;
    using System.Collections.Generic;

    public interface IOrderService
    {
        void CreateOrder(Clothing clothing, string issuerId);

        List<Order> GetOrdersByStatus(string status);
    }
}
