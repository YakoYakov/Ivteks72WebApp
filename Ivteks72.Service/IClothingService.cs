namespace Ivteks72.Service
{

    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using Ivteks72.Domain;

    public interface IClothingService
    {
        Task<Clothing> CreateClothing(string name, string fabric,
           IFormFile clothingPatternsAndCuttingDiagram, int quantity, decimal pricePerUnit);
    }
}
