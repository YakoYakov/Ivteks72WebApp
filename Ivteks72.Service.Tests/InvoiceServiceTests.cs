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

            Assert.Equal(userId, actualResult.BIlledToId);
            Assert.Equal(clothingId, actualResult.ClothingId);
            Assert.Equal(orderId, actualResult.OrderId);
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

        //IEnumerable<TViewModel> GetAllInovoicesByUserId<TViewModel>(string id);
        //TViewModel GetInvoiceById<TViewModel>(string id);
    }
}