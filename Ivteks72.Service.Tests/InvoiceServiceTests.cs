namespace Ivteks72.Service.Tests
{
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;

    using Xunit;

    using Ivteks72.App.Models.Invoice;
    using Ivteks72.Service.Tests.Common;
    using Microsoft.EntityFrameworkCore;
    using Ivteks72.Domain;
    using Ivteks72.Data;
    using Moq;
    using AutoMapper;

    public class InvoiceServiceTests
    {

        private List<Invoice> GetTestData()
        {
            return new List<Invoice>()
            {
                new Invoice
                {
                   BilledTo = new ApplicationUser(),
                   Clothing = new Clothing(),
                   Order = new Order(),
                },
                new Invoice
                {
                   BilledTo = new ApplicationUser(),
                   Clothing = new Clothing(),
                   Order = new Order(), 
                },
            };
        }

        private async Task SeedData(Ivteks72DbContext context)
        {
            context.AddRange(GetTestData());
            await context.SaveChangesAsync();
        }

        public InvoiceServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task OnCreateInvoiceAsyncServiceShouldCreateNewInvoice()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new InvoiceService(context);

            var userId = "userId";
            var clothingId = "clothingId";
            var orderId = "orderId";

            await service.CreateInvoiceAsync(userId, clothingId, orderId);

            var actualResult = await context.Invoices.FirstOrDefaultAsync();

            Assert.NotNull(actualResult);
        }

        [Fact]
        public void GetAllInvoiceByUserIdShouldReturnEmptyListIfThereIsNoSuchUser()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new InvoiceService(context);

            var fakeId = "Fake";
            var invoiceFromDb = service.GetAllInovoicesByUserId<InvoiceViewModel>(fakeId);

            Assert.Empty(invoiceFromDb);
        }

        [Fact]
        public async Task GetAllInvoiceByUserIdShouldReturnWithCorrectIdTheUserInvoices()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var methodResult = new List<InvoiceViewModel>();
            var orderFromDb = GetTestData().FirstOrDefault();

            var expectedResult = Mapper.Map<Invoice, InvoiceViewModel>(orderFromDb);

            methodResult.Add(expectedResult);

            var id = expectedResult.Id;

            var InvoiceService = new Mock<IInvoiceService>();
            InvoiceService.Setup(g => g.GetAllInovoicesByUserId<InvoiceViewModel>(id)).Returns(methodResult);

            var actualResult = InvoiceService.Object.GetAllInovoicesByUserId<InvoiceViewModel>(id);

            Assert.Equal(expectedResult.Id, actualResult.FirstOrDefault().Id);            
        }

        [Fact]
        public void GetAllInvoiceShouldReturnEmptyListIfThereIsNoIvoices()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new InvoiceService(context);

            var invoiceFromDb = service.GetAllInovoices<InvoiceViewModel>();

            Assert.Empty(invoiceFromDb);
        }

        [Fact]
        public void GetAllInvoiceShuldReturnAllInvoicesInTheDataBase()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new InvoiceService(context);

            var expectedResult = GetTestData();
            var actualResult = service.GetAllInovoices<InvoiceViewModel>().ToList();

            for (int i = 0; i < actualResult.Count(); i++)
            {
                Assert.Equal(expectedResult[i].Id, actualResult[i].Id);
            }
        }

        [Fact]
        public async Task GetInvoiceByIdShouldReturnWithCorrectIdTheInvoice()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);

            var orderFromDb = GetTestData().FirstOrDefault();

            var expectedResult = Mapper.Map<Invoice, InvoiceViewModel>(orderFromDb);

            var id = expectedResult.Id;

            var InvoiceService = new Mock<IInvoiceService>();
            InvoiceService.Setup(g => g.GetInvoiceById<InvoiceViewModel>(id)).Returns(expectedResult);

            var actualResult = InvoiceService.Object.GetInvoiceById<InvoiceViewModel>(id);

            Assert.Equal(expectedResult.Id, actualResult.Id);
        }

        [Fact]
        public async Task GetInvoiceByIdShouldReturnWithMissingIdNull()
        {
            var context = InMemoryDatabase.GetDbContext();
            await SeedData(context);
            var service = new InvoiceService(context);
            var fakeId = "FakeId";

            var actualResult = service.GetInvoiceById<InvoiceViewModel>(fakeId);

            Assert.Null(actualResult);
        }
    }
}