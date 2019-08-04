namespace Ivteks72.Service.Tests
{
    using System.Threading.Tasks;
    using System.IO;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Internal;

    using Ivteks72.Domain;
    using Ivteks72.Service.Tests.Common;

    using Moq;

    using Xunit;

    public class ClothingServiceTests
    {
        [Fact]
        public async Task OnCreateClothingAsyncServiceShouldCreateNewClothing()
        {
            IFormFile file = null;
            string filename = "SomeName";

            Mock<ICloudinaryService> cloudinaryServiceMoq = new Mock<ICloudinaryService>();
            var filemoq = cloudinaryServiceMoq.Setup(x => x.UploadDiagramImage(file, filename)).Returns(Task.Run(() => filename));
            
            var context = InMemoryDatabase.GetDbContext();

            string name = "Jacket";
            string fabric = "Textile";
            FormFile fileForDb = null;

            using (var stream = File.OpenRead("D:\\Ivteks72.App\\Ivteks72WebApp\\Ivteks72.App\\wwwroot\\lib\\pictures\\Location.png"))
            {
                fileForDb = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/pdf"
                };
            }

            int quantity = 1;
            decimal pricePerUnit = 2.20m;

            var service = new ClothingService(context, cloudinaryServiceMoq.Object);

            var testClothing = new Clothing
            {
                ClothingDiagramURL = null,
                Fabric = fabric,
                Name = name,
                PricePerUnit = pricePerUnit,
                Quantity = quantity,
            };

            var actualclothing = await service.CreateClothingAsync(name, fabric, fileForDb, quantity, pricePerUnit);

            Assert.IsAssignableFrom(testClothing.GetType(), actualclothing);
        }
    }
}
