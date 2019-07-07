namespace Ivteks72.Service
{
    using Ivteks72.Domain;

    public interface IOrderService
    {
        void CreateOrder(Clothing clothing, string issuerId);
    }
}
