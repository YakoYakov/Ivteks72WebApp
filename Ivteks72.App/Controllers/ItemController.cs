using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ivteks72.App.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult ItemsList()
        {
            return View();
        }
    }
}
