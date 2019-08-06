namespace Ivteks72.Service.Tests
{
    using Ivteks72.Domain;
    using Ivteks72.Service.Tests.Common;
    using System.Threading.Tasks;
    using Xunit;

    public class OrderServiceTests
    {
        public OrderServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task CreateOrderAsyncShoulCreateANewOrder()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new OrderService(context);

            var clothing = new Clothing();
            var issuerId = "id";

            await service.CreateOrderAsync(clothing, issuerId);

            Assert.NotEmpty(context.Orders);
        }
    }
}


//Task CreateOrderAsync(Clothing clothing, string issuerId);
//List<TOrderViewModel> GetOrdersByStatus<TOrderViewModel>(OrderStatus status, string username);
//List<TOrderViewModel> GetAllOrdersSortedByUserThenByCompany<TOrderViewModel>();
//TOrderViewModel GetOrderById<TOrderViewModel>(string id);
//Task EditOrderStatusAsync(string id, string newStatus);
//Order GetOrderFromDbById(string id);