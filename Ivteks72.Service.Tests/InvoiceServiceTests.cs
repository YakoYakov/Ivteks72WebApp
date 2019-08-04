namespace Ivteks72.Service.Tests
{
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;

    using Xunit;

    using Ivteks72.App.Models.Invoice;
    using Ivteks72.Service.Tests.Common;
    using Ivteks72.Domain;

    public class InvoiceServiceTests
    {
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

            Assert.True(context.Clothings.Any());
        }

        [Fact]
        public void GetAllInvoicesShoulReturnNullIfThereAreNoInvoicesInDb()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new InvoiceService(context);

            var nullInvoices = service.GetAllInovoices<InvoiceViewModel>();

            Assert.Empty(nullInvoices);
        }

        [Fact]
        public void GetAllInvoicesShoulReturnAllInvoicesFromDb()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new InvoiceService(context);

            var invoices = new List<InvoiceViewModel>();

            var actualResult = service.GetAllInovoices<InvoiceViewModel>();

            Assert.Equal(invoices, actualResult);
        }

        [Fact]
        public void GetAllInvoiceByUserIdShuldReturnNullIfThereIsNoSuchUser()
        {
            var context = InMemoryDatabase.GetDbContext();
            var service = new InvoiceService(context);

            var fakeId = "Fake";
            var invoiceFromDb = service.GetAllInovoicesByUserId<InvoiceViewModel>(fakeId);

            var actualResult = invoiceFromDb.Select(x => x.BIlledToUser).FirstOrDefault();

            Assert.Null(actualResult);
        }
    }
}

//IEnumerable<TViewModel> GetAllInovoicesByUserId<TViewModel>(string id); one more test !
//IEnumerable<TViewModel> GetAllInovoices<TViewModel>();
//TViewModel GetInvoiceById<TViewModel>(string id);