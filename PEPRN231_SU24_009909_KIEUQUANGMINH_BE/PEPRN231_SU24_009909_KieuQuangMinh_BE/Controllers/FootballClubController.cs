using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Services;

namespace PEPRN231_SU24_009909_KieuQuangMinh_BE.Controllers
{
    public class FootballClubController:ODataController
    {
        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var _service = new FootballClubService();
                return Ok(_service.GetAll().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
