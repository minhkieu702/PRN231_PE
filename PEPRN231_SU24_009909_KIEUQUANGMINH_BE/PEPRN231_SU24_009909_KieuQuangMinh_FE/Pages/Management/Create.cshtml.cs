using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PEPRN231_SU24_009909_KieuQuangMinh_FE.Models;

namespace PEPRN231_SU24_009909_KieuQuangMinh_FE.Pages.Management
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public FootballPlayer FootballPlayer { get; set; } = default!;

        [BindProperty]
        public List<FootballClub> FootballClubs { get; set; } = default!;

        private async Task GetClubs(string token)
        {
            var response = await Common.SendRequestAsync($"{Common.BaseURL}/api/FootballClubs", HttpMethod.Get, null, token);
            if (!response.IsSuccessStatusCode)
            {
                TempData["error"] = await Common.ReadError(response);
                return;
            }
            FootballClubs = await Common.ReadT<List<FootballClub>>(response);
        }

        public async Task<IActionResult> OnGet()
        {
            var token = HttpContext.Session.GetString("token");
            if (!Common.CheckPermission(token, [1]))
            {
                TempData["error"] = Common.NoPermissionMessage;
                return RedirectToPage("./Index");
            }
            await GetClubs(token);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var token = HttpContext.Session.GetString("token");
            if (!Common.CheckPermission(token, [1]))
            {
                return RedirectToPage("./Index");
            }
            if (!ModelState.IsValid)
            {
                await GetClubs(token);
                return Page();
            }
            var response = await Common.SendRequestAsync($"{Common.BaseURL}/api", HttpMethod.Post, FootballPlayer, token);
            if (!response.IsSuccessStatusCode)
            {
                TempData["errror"] = await Common.ReadError(response);
                await GetClubs(token);
                return Page();
            }
            TempData["info"] = "Added successfully";
            return RedirectToPage("./Index");
        }
    }
}
