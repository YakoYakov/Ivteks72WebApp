using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ivteks72.App.Areas.Identity.Pages.Account
{
    public class ConfirmationEmailSendModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}