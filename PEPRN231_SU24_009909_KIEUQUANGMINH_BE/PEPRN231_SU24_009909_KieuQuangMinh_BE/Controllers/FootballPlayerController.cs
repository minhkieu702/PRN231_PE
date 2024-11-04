using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repositories;
using Repositories.Repositories;
using Services;

namespace PEPRN231_SU24_009909_KieuQuangMinh_BE.Controllers
{
    public class FootballPlayerController : ODataController
    {
        FootballPlayerService _service = new();

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAll().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("player")]
        public IActionResult Add([FromBody] FootballPlayer footballPlayer)
        {
            try
            {
                _service.Add(footballPlayer);
                return Ok(footballPlayer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("player/{id}")]
        public IActionResult Update(string id, [FromBody] FootballPlayer footballPlayer)
        {
            try
            {
                _service.Update(id, footballPlayer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("player/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _service.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
