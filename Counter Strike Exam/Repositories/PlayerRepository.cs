using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly ICollection<IPlayer> players;
        public IReadOnlyCollection<IPlayer> Models =>
            (IReadOnlyCollection<IPlayer>)this.players;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            players.Add(model);
        }

        public IPlayer FindByName(string name) =>
            this.players.FirstOrDefault(n => n.Username == name);


        public bool Remove(IPlayer model) =>
            this.players.Remove(model);
    }
}
