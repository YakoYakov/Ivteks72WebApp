using Ivteks72.Data;
using Ivteks72.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Ivteks72.Service.Tests
{
    public class ClothingServiceTests
    {
        [Fact]
        public async Task OnCreateClothingAsyncServiceShouldCreateNewClothing()
        {
            //Moq of the cloudinary service if needed.
            IFormFile file = null;
            string filename = "SomeName";
            Mock<ICloudinaryService> cloudinaryServiceMoq = new Mock<ICloudinaryService>();
            cloudinaryServiceMoq.Setup(x => x.UploadDiagramImage(file, filename));
            

            var optionsBuilder = new DbContextOptionsBuilder<Ivteks72DbContext>()
                .UseInMemoryDatabase("TestDatabase");

            string name = "Jacket";
            string fabric = "Textile";
            IFormFile fileForDb = null;
            int quantity = 1;
            decimal pricePerUnit = 2.20m;

            var service = new ClothingService(new Ivteks72DbContext(optionsBuilder.Options), cloudinaryServiceMoq.Object);

            var testClothign = new Clothing
            {
                Fabric = fabric,
                Name = name,
                PricePerUnit = pricePerUnit,
                Quantity = quantity
            };

            var Actualclothing = await service.CreateClothingAsync(name, fabric, fileForDb, quantity, pricePerUnit);

            Assert.True(testClothign.Equals(Actualclothing));
        }
    }
}
