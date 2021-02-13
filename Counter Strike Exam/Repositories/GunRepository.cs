using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => 
            (IReadOnlyCollection<IGun>)this.guns;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            guns.Add(model);
        }

        public IGun FindByName(string name) =>
            this.guns.FirstOrDefault(n => n.Name == name);


        public bool Remove(IGun model) =>
            this.guns.Remove(model);
        
    }
}
