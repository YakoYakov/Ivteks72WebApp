﻿namespace Ivteks72.App.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.App.Models;
    using Ivteks72.App.Models.Contact;
    using Ivteks72.App.Services;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Http;
    using System;

    public class HomeController : Controller
    {
        private readonly ISendGridEmailSender emailSender;

        public HomeController(ISendGridEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.emailSender.SendContactFormEmailAsync(model.Email, model.Name + " " + model.Subject, model.Massage);

            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1)}
                );

            return LocalRedirect(returnUrl);
        }
    }
}
