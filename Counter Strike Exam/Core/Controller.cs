using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;
        private readonly IRepository<IPlayer> players;
        private ICollection<IPlayer> Players;
        private IMap map;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
            this.Players = new List<IPlayer>();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if(type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player = null;
            IGun gun = guns.FindByName(gunName);

            

            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if(type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }

            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            this.players.Add(player);
            guns.Remove(gun);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
        }

        public string StartGame()
        {
            this.Players = players.Models.ToList();
            
            return map.Start(this.Players);
        }

        public string Report()
        {
            this.players.Models.OrderBy(t => t.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(u => u.Username)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var pl in players.Models)
            {
                sb.AppendLine(pl.ToString());
                
            }
            return sb.ToString().TrimEnd();
        }

       
    }
}
