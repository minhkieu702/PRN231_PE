using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PEPRN231_SU24_009909_KieuQuangMinh_FE.Models;

namespace PEPRN231_SU24_009909_KieuQuangMinh_FE.Pages.Management
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public FootballPlayer FootballPlayer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var token = HttpContext.Session.GetString("token");
            if (!Common.CheckPermission(token, [1, 2]))
            {
                TempData["error"] = Common.NoPermissionMessage;
                return RedirectToPage("../Index");
            }
            var url = $"{Common.BaseURL}/odata/FootballPlayer?$expand=FootballClub&$filter=FootballPlayerId eq '{id}'";
            var response = await Common.SendRequestAsync(url, HttpMethod.Get, null, token);
            if (!response.IsSuccessStatusCode)
            {
                TempData["errror"] = await Common.ReadError(response);
                return Page();
            }
            var footballPlayerList = await Common.ReadT<List<FootballPlayer>>(response, true);
            FootballPlayer = footballPlayerList.FirstOrDefault();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var token = HttpContext.Session.GetString("token");
            if (!Common.CheckPermission(token, [1]))
            {
                return RedirectToPage("./Index");
            }
            var response = await Common.SendRequestAsync($"{Common.BaseURL}/api/{FootballPlayer.FootballPlayerId}", HttpMethod.Delete, null, token);
            if (!response.IsSuccessStatusCode)
            {
                TempData["errror"] = await Common.ReadError(response);
                return Page();
            }
            TempData["info"] = "Deleted successfully";
            return RedirectToPage("./Index");
        }
    }
}
