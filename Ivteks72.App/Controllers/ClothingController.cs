namespace Ivteks72.App.Controllers
{
    using Ivteks72.App.Models.Clothing;
    using Ivteks72.Service;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ClothingController : Controller
    {
        private readonly IClothingService clothingService;

        public ClothingController(IClothingService clothingService)
        {
            this.clothingService = clothingService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ClothingCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.clothingService.CreateClothing(model.Name, model.Fabric, model.ClothingPatternsAndCuttingDiagram, model.PricePerUnit);

            return this.Redirect("/");
        }
    }
}
