namespace Ivteks72.Service.Tests
{
    using Ivteks72.Data;
    using Ivteks72.Domain;
    using Ivteks72.Domain.Enums;
    using Ivteks72.Service.Tests.Common;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class OrderServiceTests
    {
        private List<Order> GetTestData()
        {
            return new List<Order>()
            {
                new Order
                {
                    Clothing = new Clothing(),
                    Issuer = new ApplicationUser
                    {
                        UserName = "FirstName"
                    },
                    Status = OrderStatus.Finished,
                },
                new Order
                {
                    Clothing = new Clothing(),
                    Issuer = new ApplicationUser
                    {
                        UserName = "SecondName"
                    },
                    Status = OrderStatus.Pending,
                },
                new Order
                {
                    Clothing = new Clothing(),
                    Issuer = new ApplicationUser
                    {
                        UserName = "ThirdName"
                    },
                    Status = OrderStatus.Finished,
                }
            };
        }

        private async Task SeedData(Ivteks72DbContext context)
        {
            context.AddRange(GetTestData());
            await context.SaveChangesAsync();
        }

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

        [Fact]
        public async Task GetOrderFromDbByIdShouldReturnTheCorrectOrder()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var orderService = new Mock<IOrderService>();

            var expectedResult = GetTestData().First();

            orderService.Setup(g => g.GetOrderFromDbById(expectedResult.Id)).Returns(expectedResult);

            var service = orderService.Object;
            var actualResult = service.GetOrderFromDbById(expectedResult.Id);

            Assert.Same(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetOrderFromDbByIdWhitNoneexistenceIdShouldReturnNull()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var orderService = new Mock<IOrderService>();

            var fakeId = "nonexistent";
            var order = new Order();
            orderService.Setup(g => g.GetOrderFromDbById("Id")).Returns(order);

            var service = orderService.Object;
            var actualResult = service.GetOrderFromDbById(fakeId);

            Assert.Null(actualResult);
        }
    }
}


//List<TOrderViewModel> GetOrdersByStatus<TOrderViewModel>(OrderStatus status, string username);
//List<TOrderViewModel> GetAllOrdersSortedByUserThenByCompany<TOrderViewModel>();
//TOrderViewModel GetOrderById<TOrderViewModel>(string id);
//Task EditOrderStatusAsync(string id, string newStatus);
//Order GetOrderFromDbById(string id);