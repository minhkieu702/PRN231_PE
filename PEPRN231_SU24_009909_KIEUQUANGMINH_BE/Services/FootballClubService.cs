using Repositories;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FootballClubService
    {
        FootballClubRepository repository = new();
        public List<FootballClub> GetAll() => repository.GetAll();
    }
}
