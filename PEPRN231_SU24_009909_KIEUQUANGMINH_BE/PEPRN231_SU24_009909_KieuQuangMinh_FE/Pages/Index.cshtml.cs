using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PEPRN231_SU24_009909_KieuQuangMinh_FE.Models;
using System.ComponentModel.DataAnnotations;

namespace PEPRN231_SU24_009909_KieuQuangMinh_FE.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await Common.SendRequestAsync($"{Common.BaseURL}/odata/Auth", HttpMethod.Post, new {password = Password, emailAddress = EmailAddress});

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                TempData["error"] = await Common.ReadError(response);
                return Page();
            }

            var token = await Common.ReadToken(response);
            
            Common.DecodeJwtToken(token, out string id, out string role);
            
            HttpContext.Session.SetString("token", token);

            if (Common.CheckPermission(token, [1, 2]))
            {
                return RedirectToPage("/Management/Index");
            }
            TempData["error"] = Common.NoPermissionMessage;
            return Page();
        }
    }
}
