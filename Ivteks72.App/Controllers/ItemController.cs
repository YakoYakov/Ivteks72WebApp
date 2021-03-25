using Ivteks72.App.Models.Item;
using Ivteks72.Data;
using Ivteks72.Domain;
using Ivteks72.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ivteks72.App.Controllers
{
    public class ItemController : Controller
    {
        private readonly Ivteks72DbContext context;
        private readonly ICloudinaryService cService;
        public ItemController(Ivteks72DbContext context, ICloudinaryService cService)
        {
            this.context = context;
            this.cService = cService;
        }
        // TODO maybe remove?
        public IActionResult ItemsList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewItem(AddItemViewModel model, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                this.ModelState.AddModelError("picError", "You have to provide a photo");
                return this.View(model);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var itemUrl = await this.cService.UploadDiagramImage(photo, photo.FileName);

            // TODO make it through service!!!
            Item item = new Item()
            {
                Type = model.Type,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                ImageUrl = itemUrl
            };

            await this.context.Items.AddAsync(item);
            await this.context.SaveChangesAsync();
            return View();
        }
    }
}
