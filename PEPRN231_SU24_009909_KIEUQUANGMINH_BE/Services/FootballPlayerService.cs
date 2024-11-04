using Repositories;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FootballPlayerService
    {
        FootballPlayerRepository repository = new();

        public List<FootballPlayer> GetAll() => repository.GetAll();

        public void Add(FootballPlayer model) => repository.Add(model);

        public void Remove(string id) => repository.Delete(id);

        public void Update(string id, FootballPlayer model) => repository.Update(id, model);
    }
}
