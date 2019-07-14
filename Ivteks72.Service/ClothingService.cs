﻿namespace Ivteks72.Service
{
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using Ivteks72.Data;
    using Ivteks72.Domain;
    using System.Drawing;

    public class ClothingService : IClothingService
    {
        private readonly Ivteks72DbContext context;

        public ClothingService(Ivteks72DbContext context)
        {
            this.context = context;
        }

        public async Task<Clothing> CreateClothing(string name, string fabric, IFormFile photo, int quantity, decimal pricePerUnit)
        {
            var stream = photo.OpenReadStream();

            byte[] imageInByteArray = StreamToByteArray(stream);

            var clothing = new Clothing
            {
                Fabric = fabric,
                Name = name,
                PricePerUnit = pricePerUnit,
                Quantity = quantity,
                ClothingPatternsAndCuttingDiagram = imageInByteArray
            };

            await this.context.Clothings.AddAsync(clothing);
            await this.context.SaveChangesAsync();

            return clothing;
        }

        private byte[] StreamToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
