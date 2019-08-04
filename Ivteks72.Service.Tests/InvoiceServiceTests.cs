namespace Ivteks72.Service.Tests
{
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;

    using Xunit;

    using Ivteks72.App.Models.Invoice;
    using Ivteks72.Service.Tests.Common;

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

    }
}

//IEnumerable<TViewModel> GetAllInovoicesByUserId<TViewModel>(string id);
//IEnumerable<TViewModel> GetAllInovoices<TViewModel>();
//TViewModel GetInvoiceById<TViewModel>(string id);