using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class PremierLeagueAccountRepository
    {
        public PremierLeagueAccount Login(string email, string password)
        {
			try
			{
				var _context = new EnglishPremierLeague2024DbContext();

                var result = _context.PremierLeagueAccounts.FirstOrDefault(c => c.EmailAddress.Equals(email) && c.Password.Equals(password));
                
                if (result == null) throw new Exception("This action is failed");

                return result;
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
