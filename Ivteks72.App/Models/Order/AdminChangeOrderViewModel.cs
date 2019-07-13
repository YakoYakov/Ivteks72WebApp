namespace Ivteks72.App.Models.Order
{
    using Ivteks72.AutoMapping;
    using Ivteks72.Domain;

    public class AdminChangeOrderViewModel : IMapFrom<Order>
    {
        public string OrderStatus { get; set; }
    }
}
