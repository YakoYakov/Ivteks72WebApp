namespace Ivteks72.Service
{

    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using Ivteks72.Domain;

    public interface IClothingService
    {
        Task<Clothing> CreateClothingAsync(string name, string fabric,
           IFormFile clothingPatternsAndCuttingDiagram, int quantity, decimal pricePerUnit);

        //Image GetOrderImage(string orderId);
    }
}
