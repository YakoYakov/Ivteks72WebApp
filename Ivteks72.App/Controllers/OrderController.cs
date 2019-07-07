namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class OrderController : Controller
    {
        public IActionResult OrderIndex()
        {
            return this.View();
        }

        public IActionResult ViewAll()
        {
            return this.View();
        }
    }
}
