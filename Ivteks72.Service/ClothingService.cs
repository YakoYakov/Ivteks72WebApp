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

        public void CreateClothing(string name, string fabric, IFormFile clothingPatternsAndCuttingDiagram, decimal pricePerUnit)
        {
            //byte[] imageInByteArray = File.ReadAllBytes("clothingPatternsAndCuttingDiagram");

            var clothing = new Clothing
            {
                Fabric = fabric,
                Name = name,
                PricePerUnit = pricePerUnit,
                //ClothingPatternsAndCuttingDiagram = imageInByteArray
            };

            this.context.Clothings.Add(clothing);
            this.context.SaveChanges();
        }
    }
}
