using Repositories;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PremierLeagueAccountService
    {
        PremierLeagueAccountRepository repository = new();

        public PremierLeagueAccount Login(string email, string password) => repository.Login(email, password);
    }
}
