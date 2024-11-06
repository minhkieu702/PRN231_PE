using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Repositories.Repositories;
using Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PEPRN231_SU24_009909_KieuQuangMinh_BE.Controllers
{
    [Route("api")]
    public class FootballPlayerController : ODataController
    {
        FootballPlayerService _service = new();
        private readonly IConfiguration _config;

        public FootballPlayerController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [EnableQuery]
        [HttpPost("login")]
        public IActionResult Login([FromBody] PremierLeagueAccount model)
        {
            try
            {
                var _service = new PremierLeagueAccountService();
                return Ok(GenerateJwtToken(_service.Login(model.EmailAddress, model.Password)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableQuery]
        [HttpGet("FootballClubs")]
        public IActionResult GetCLubs()
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

        [EnableQuery]
        [HttpPost]
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

        [EnableQuery]
        [HttpPut("{id}")]
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

        [EnableQuery]
        [HttpDelete("{id}")]
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

        private string GenerateJwtToken(PremierLeagueAccount account)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.AccId.ToString()),
                new Claim(ClaimTypes.Role, account.Role.ToString()),
                new Claim(ClaimTypes.Email, account.EmailAddress),
            };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(120),
                    signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
