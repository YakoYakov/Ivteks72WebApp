namespace Ivteks72.Service
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using Ivteks72.Data;
    using Ivteks72.Domain;

    public class ClothingService : IClothingService
    {
        private readonly Ivteks72DbContext context;
        private readonly ICloudinaryService cloudinaryService;

        public ClothingService(Ivteks72DbContext context, ICloudinaryService cloudinaryService)
        {
            this.context = context;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<Clothing> CreateClothing(string name, string fabric, IFormFile photo, int quantity, decimal pricePerUnit)
        {

            var clothingDiagramImageURL = await this.cloudinaryService.UploadDiagramImage(photo, photo.FileName);

            var clothing = new Clothing
            {
                Fabric = fabric,
                Name = name,
                PricePerUnit = pricePerUnit,
                Quantity = quantity,
                ClothingDiagramURL = clothingDiagramImageURL
            };

            await this.context.Clothings.AddAsync(clothing);
            await this.context.SaveChangesAsync();


            return clothing;
        }
    }
}
