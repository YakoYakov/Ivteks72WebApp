namespace Ivteks72.Service
{
    using System;
    using System.IO;
    using Ivteks72.Data;
    using Ivteks72.Domain;
    using Microsoft.AspNetCore.Http;

    public class ClothingService : IClothingService
    {
        private readonly Ivteks72DbContext context;

        public ClothingService(Ivteks72DbContext context)
        {
            this.context = context;
        }

        public void CreateClothing(string name, string fabric, IFormFile photo, decimal pricePerUnit)
        {
            var stream = photo.OpenReadStream();

            byte[] imageInByteArray = StreamToByteArray(stream);

            var clothing = new Clothing
            {
                Fabric = fabric,
                Name = name,
                PricePerUnit = pricePerUnit,
                ClothingPatternsAndCuttingDiagram = imageInByteArray
            };

            this.context.Clothings.Add(clothing);
            this.context.SaveChanges();
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
    }
}
