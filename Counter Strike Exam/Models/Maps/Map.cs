using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private ICollection<IPlayer> terrorist;
        private ICollection<IPlayer> counterTerrorist;

        public Map()
        {
            terrorist = new List<IPlayer>();
            counterTerrorist = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            terrorist = players.Where(t => t.GetType().Name == "Terrorist").ToList();
            counterTerrorist = players.Where(t => t.GetType().Name == "CounterTerrorist").ToList();

            while (terrorist.Any(h => h.Health > 0) && counterTerrorist.Any(h => h.Health > 0))
            {
                foreach (var TER in terrorist)
                {
                    foreach (var CT in counterTerrorist)
                    {
                        CT.TakeDamage(TER.Gun.Fire());
                    }
                }

                if (counterTerrorist.Any(h => h.Health > 0) && counterTerrorist.Any(h => h.Health > 0))
                {
                    foreach (var CT in counterTerrorist)
                    {
                        foreach (var TER in terrorist)
                        {
                            TER.TakeDamage(CT.Gun.Fire());
                        }
                    }
                }
            }

            string msg = null;
            if (counterTerrorist.Any(h => h.Health > 0))
            {
                msg = "Counter Terrorist wins!";
            }
            else if (terrorist.Any(h => h.Health > 0))
            {
                msg = "Terrorist wins!";
            }

            return msg;
        }
    }
}
