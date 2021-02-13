using Raiding.Models;

namespace Raiding.HeroCreation
{
    public class WarriorFactory : HeroFactory
    {
        private string _name;

        public WarriorFactory(string name)
        {
            _name = name;
        }
        public override BaseHero GetBaseHero()
        {
            return new Warrior(_name);
        }
    }
}
