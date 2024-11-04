using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class FootballPlayerRepository
    {
        public List<FootballPlayer> GetAll()
        {
			try
			{
                var context = new EnglishPremierLeague2024DbContext();
                return context.FootballPlayers
                    .Include(c => c.FootballClub)
                    .ToList();
            }
			catch (Exception)
			{

				throw;
			}
        }

        public void Update(string id, FootballPlayer model)
        {
			try
			{
				model.FootballPlayerId = id;
                
                var _context = new EnglishPremierLeague2024DbContext();
                
                var result = _context.FootballPlayers.AsNoTracking().FirstOrDefault(c => c.FootballPlayerId == id);
                
                if (result == null)
                    throw new Exception("This id is not existed");

                result = model;

                _context.FootballPlayers.Update(result);

                if (_context.SaveChanges() == 0) throw new Exception("This action is failed");
            }
			catch (Exception)
			{

				throw;
			}
        }

        public void Delete(string id)
        {
            try
            {
                var _context = new EnglishPremierLeague2024DbContext();

                var result = _context.FootballPlayers.AsNoTracking().FirstOrDefault(c => c.FootballPlayerId == id);

                if (result == null)
                    throw new Exception("This id is not existed");

                _context.FootballPlayers.Remove(result);

                if (_context.SaveChanges() == 0) throw new Exception("This action is failed");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Add(FootballPlayer model)
        {
            try
            {
                var _context = new EnglishPremierLeague2024DbContext();

                var result = _context.FootballPlayers.Find(model.FootballPlayerId);

                if (result != null) throw new Exception("This id is already existed");

                _context.FootballPlayers.Add(model);

                if (_context.SaveChanges() == 0) throw new Exception("This action is failed");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
