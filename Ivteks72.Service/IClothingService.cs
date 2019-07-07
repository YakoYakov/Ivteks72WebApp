namespace Ivteks72.Service
{
    using Ivteks72.Domain;
    using Microsoft.AspNetCore.Http;

    public interface IClothingService
    {
        Clothing CreateClothing(string name, string fabric, 
            IFormFile clothingPatternsAndCuttingDiagram, int quantity, decimal pricePerUnit);
    }
}
