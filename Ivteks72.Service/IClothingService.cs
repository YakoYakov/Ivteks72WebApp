namespace Ivteks72.Service
{
    using Microsoft.AspNetCore.Http;

    public interface IClothingService
    {
        void CreateClothing(string name, string fabric, IFormFile clothingPatternsAndCuttingDiagram, decimal pricePerUnit);
    }
}
