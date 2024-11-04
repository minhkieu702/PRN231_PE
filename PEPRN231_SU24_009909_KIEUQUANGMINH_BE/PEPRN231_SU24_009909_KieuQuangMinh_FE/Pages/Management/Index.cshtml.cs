using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Common;
using PEPRN231_SU24_009909_KieuQuangMinh_FE.Models;

namespace PEPRN231_SU24_009909_KieuQuangMinh_FE.Pages.Management
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IList<FootballPlayer> FootballPlayer { get;set; } = default!;

        [BindProperty]
        public string Nomination { get; set; } = "";

        [BindProperty]
        public string Achievements { get; set; } = "";

        string url = $"{Common.BaseURL}/odata/FootballPlayer?$expand=FootballClub";

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var token = HttpContext.Session.GetString("token");
                if (!Common.CheckPermission(token, [1, 2]))
                {
                    TempData["error"] = Common.NoPermissionMessage;
                    return RedirectToPage("../index");
                }
                var response = await Common.SendRequestAsync(url, HttpMethod.Get, null, token);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "Something was wrong.";
                }
                FootballPlayer = await Common.ReadT<IList<FootballPlayer>>(response);
                return Page();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var token = HttpContext.Session.GetString("token");
                if (!Common.CheckPermission(token, [1, 2]))
                {
                    TempData["error"] = Common.NoPermissionMessage;
                    return RedirectToPage("../index");
                }
                if (!string.IsNullOrEmpty(Nomination))
                {
                    url += $"&$filter=contains(tolower(Nomination),'{Nomination.ToLower()}')";
                }

                if (!string.IsNullOrEmpty(Achievements))
                {
                    url += url.Contains("filter") ? " and " : "&$filter=";
                    url += $"contains(tolower(Achievements),'{Achievements.ToLower()}')";
                }
                var response = await Common.SendRequestAsync(url, HttpMethod.Get, null, token);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "Something was wrong.";
                    return Page();
                }
                FootballPlayer = await Common.ReadT<IList<FootballPlayer>>(response);
                return Page();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return Page();
            }
        }
    }
}
