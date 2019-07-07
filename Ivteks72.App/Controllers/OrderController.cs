namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        public IActionResult ViewAll()
        {
            return this.View();
        }
    }
}
