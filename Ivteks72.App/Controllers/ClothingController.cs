namespace Ivteks72.App.Controllers
{
    using Ivteks72.App.Models.Clothing;
    using Ivteks72.Service;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    public class ClothingController : Controller
    {
        private readonly IClothingService clothingService;
        private readonly IOrderService orderService;

        public ClothingController(IClothingService clothingService, IOrderService orderService)
        {
            this.clothingService = clothingService;
            this.orderService = orderService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClothingCreateViewModel model, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return this.View(model);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var clothing = await this.clothingService.CreateClothing(model.Name, model.Fabric, photo,
                model.Quantity, model.PricePerUnit);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.orderService.CreateOrder(clothing, userId);

            return this.Redirect("/");
        }
    }
}
