using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class FootballClubRepository
    {
        public List<FootballClub> GetAll()
        {
			try
			{
                var context = new EnglishPremierLeague2024DbContext();
                return context.FootballClubs.ToList();
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
