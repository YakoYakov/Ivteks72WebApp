namespace Ivteks72.Service.Tests
{
    using AutoMapper;
    using Ivteks72.App.Models.Order;
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

            var mockOrderService = new Mock<IOrderService>();

            var expectedResult = GetTestData().First();

            mockOrderService.Setup(g => g.GetOrderFromDbById(expectedResult.Id)).Returns(expectedResult);

            var service = mockOrderService.Object;
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

        [Fact]
        public async Task EdidOrderStatusAsyncWithExistingStatusShuldChangeTheOrderStatus()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var orderService = new OrderService(context);

            var orderToEdit = context.Orders.FirstOrDefault();
            var statusToChangeTo = "Rejected";
            var orderId = orderToEdit.Id;

            await orderService.EditOrderStatusAsync(orderId, statusToChangeTo);

            var expectedResult = OrderStatus.Rejected;
            var actualResult = orderToEdit.Status;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public async Task EditOrderStatusWithWrongStatusShouldNotChangeTheOrderStatus()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var orderService = new OrderService(context);

            var orderToEdit = context.Orders.FirstOrDefault();
            var statusToChangeTo = "FakeStatus";
            var orderId = orderToEdit.Id;

            await orderService.EditOrderStatusAsync(orderId, statusToChangeTo);

            var expectedResult = OrderStatus.Rejected;
            var actualResult = orderToEdit.Status;

            Assert.NotEqual(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetOrderByIdShouldReturnTheCorrectOrder()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var mockOrderService = new Mock<IOrderService>();

            var methodReturnValue = new OrderByStatusViewModel();
            var expectedResult = GetTestData().First();

            mockOrderService.Setup(g => g.GetOrderById<OrderByStatusViewModel>(expectedResult.Id)).Returns(methodReturnValue);

            var service = mockOrderService.Object;
            var returnedOrder = service.GetOrderById<OrderByStatusViewModel>(expectedResult.Id);

            Assert.Same(expectedResult.Clothing.Name, returnedOrder.ClothingName);
        }

        [Fact]
        public async Task GetOrderByIdWihtNonExistantIdShouldReturnNull()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var orderService = new Mock<IOrderService>();

            var fakeId = "nonexistent";
            var methodReturnValue = new OrderByStatusViewModel();

            orderService.Setup(g => g.GetOrderById<OrderByStatusViewModel>("Id")).Returns(methodReturnValue);

            var service = orderService.Object;
            var actualResult = service.GetOrderById<OrderByStatusViewModel>(fakeId);

            Assert.Null(actualResult);
        }

        [Fact]
        public async Task GetOrderByStatusWithCorrectStatusShouldReturnTheOrder()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var methodResult = new List<OrderByStatusViewModel>();

            var orderFromDb = GetTestData().FirstOrDefault();

            var expectedResult = Mapper.Map<Order, OrderByStatusViewModel>(orderFromDb,
                opt => opt.ConfigureMap()
                .ForMember(dest => dest.IssuerName, m => m.MapFrom(src => src.Issuer.UserName)));
            methodResult.Add(expectedResult);

            var orderStatus = orderFromDb.Status;
            var orderUser = orderFromDb.Issuer.UserName;

            var orderService = new Mock<IOrderService>();
            orderService.Setup(g => g.GetOrdersByStatus<OrderByStatusViewModel>(orderStatus, orderUser)).Returns(methodResult);

            var actualResult = orderService.Object.GetOrdersByStatus<OrderByStatusViewModel>(orderStatus, orderUser).FirstOrDefault();

            Assert.Same(expectedResult.IssuerName, actualResult.IssuerName);
            Assert.Same(expectedResult.OrderStatus, actualResult.OrderStatus);
        }

        [Fact]
        public void GetOrderByStatusWithIncorrectParametersShouldReturnEmptyList()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new OrderService(context);

            var missingOrderStatus = OrderStatus.Accepted;
            var missingUserName = "Missing";

            var actualResult = service.GetOrdersByStatus<OrderByStatusViewModel>(missingOrderStatus, missingUserName);

            Assert.Empty(actualResult);
        }

        [Fact]
        public async Task GetAllOrdersSortedByUserThenByCompanyShouldReturnAllOrdersInTheDataBase()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var methodResults = new List<AdminOrderViewModel>();

            var ordersFromDb = GetTestData();

            foreach (var order in ordersFromDb)
            {
                var mappedOrder = Mapper.Map<Order, AdminOrderViewModel>(order,
                opt => opt.ConfigureMap()
                .ForMember(dest => dest.IssuerName, m => m.MapFrom(src => src.Issuer.UserName)));
                methodResults.Add(mappedOrder);
            }

            var orderService = new Mock<IOrderService>();
            orderService.Setup(g => g.GetAllOrdersSortedByUserThenByCompany<AdminOrderViewModel>()).Returns(methodResults);

            var actualResults = orderService.Object.GetAllOrdersSortedByUserThenByCompany<AdminOrderViewModel>();

            for (int i = 0; i < methodResults.Count; i++)
            {
                Assert.Same(methodResults[i].IssuerName, actualResults[i].IssuerName);
                Assert.Same(methodResults[i].OrderStatus, actualResults[i].OrderStatus);
            }
        }

        [Fact]
        public void GetAllOrdersSortedByUserThenByCompanyWithNoOrdersInDataBaseShouldReturnEmpyList()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new OrderService(context);

            var actualResult = service.GetAllOrdersSortedByUserThenByCompany<AdminOrderViewModel>();

            Assert.Empty(actualResult);
        }
    }
}